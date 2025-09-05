using ApiAndDatabaseSample.Api.Models.Repositories;
using ApiAndDatabaseSample.Api.Models.Services;
using Microsoft.Data.SqlClient;
using System.Data.Common;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
// Add services to the container.

Console.WriteLine(configuration.GetConnectionString("Default"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<DbConnection>(sp => new SqlConnection(configuration.GetConnectionString("Default")));
builder.Services.AddScoped<ITodoRepository, TodoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
    }
    else
    {
        await next(); // Continue to the next middleware
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
