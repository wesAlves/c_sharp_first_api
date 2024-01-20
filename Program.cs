using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo() { Title = "First API", Description = "Just an API test", Version = "1.0.0" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fist API test v1"); });

app.MapGet("/", () => "Hello world");

app.Run();