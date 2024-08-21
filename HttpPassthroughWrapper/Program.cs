using HttpPassthroughWrapper;
using HttpPassthroughWrapper.Client;
using HttpPassthroughWrapper.Client.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPokeApiClient, PokeApiClient>();
builder.Services.AddHttpClient<IPokeApiClient, PokeApiClient>();

builder.Services.AddScoped(typeof(IPassthroughHandler<>), typeof(PassthroughHandler<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/test", async (IPassthroughHandler<IPokeApiClient> httpPassthroughWrapper) =>
    {
        var result =
            await httpPassthroughWrapper.HandleAsync<PokeApiResponse?>(async client => await client.GetPokemonById(1));

        if (result.SucessResult is not null)
        {
            return Results.Ok(
                result.SucessResult.Name
            );
        }

        return result.ErrorResult;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();