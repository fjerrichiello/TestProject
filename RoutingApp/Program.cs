// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using RoutingApp;
using RoutingApp.BookActivityOperations;
using RoutingApp.DummyResources;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddScoped<IRouterParameterFactory, RouterParameterFactory>();

services.AddScoped<IBookActivityRouter, BookActivityRouter>();

services.AddKeyedScoped<IBookActivityOperation, AddBookApproved>(nameof(AddBookApproved));
services.AddKeyedScoped<IBookActivityOperation, AddBookDenied>(nameof(AddBookDenied));
services.AddKeyedScoped<IBookActivityOperation, EditBookApproved>(nameof(EditBookApproved));
services.AddKeyedScoped<IBookActivityOperation, EditBookDenied>(nameof(EditBookDenied));
services.AddKeyedScoped<IBookActivityOperation, NoOperation>(nameof(NoOperation));

services.AddScoped<IService1, Service1>();

services.AddScoped<IService2, Service2>();

services.AddScoped<IHandler, Handler>();
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

app.MapGet("/test", async (IHandler handler) => { await handler.UseHandler(new Command(0, "1234")); });
app.Run();