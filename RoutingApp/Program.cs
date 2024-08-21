// See https://aka.ms/new-console-template for more information

using RoutingApp;
using RoutingApp.BookActivityOperations;
using RoutingApp.DummyResources;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddScoped<IRouterParameterFactory, RouterParameterFactory>();

services.AddScoped<IBookActivityRouter, BookActivityRouter>();

services.AddOperations(typeof(AddBookApproved));

services.AddScoped<IService1, Service1>();
services.AddScoped<IService2, Service2>();

services.AddScoped<IRepository1, Repository1>();
services.AddScoped<IRepository2, Repository2>();

services.AddScoped<IHandler, Handler>();
services.AddScoped<IMetadataAccessor, MetadataAccessor>();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.MapGet("/test", async (IHandler handler, IMetadataAccessor accessor) =>
{
    accessor.Metadata = "Start of data";
    await handler.UseHandler(new Command(0, "1234"));
});
app.Run();