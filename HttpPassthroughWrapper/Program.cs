using HttpPassthroughWrapper;
using HttpPassthroughWrapper.Client;
using HttpPassthroughWrapper.Client.Models;
using HttpPassthroughWrapper.CustomResultObject;
using HttpPassthroughWrapper.WithMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPokeApiClient, PokeApiClient>();
builder.Services.AddHttpClient<IPokeApiClient, PokeApiClient>();

builder.Services.AddScoped(typeof(IPassthroughHandler<>), typeof(PassthroughHandler<>));
builder.Services.AddScoped(typeof(IPassthroughHandlerWithMapper<>), typeof(PassthroughHandlerWithMapper<>));

builder.Services.AddScoped<IMapper<PokeApiResponse, PokemonApiDto>, ModelMapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/test", async (IPassthroughHandlerWithMapper<IPokeApiClient> httpPassthroughWrapper) =>
    {
        return await httpPassthroughWrapper.HandleAsync<PokeApiResponse?, PokemonApiDto>(async client =>
            await client.GetPokemonById(1));
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();