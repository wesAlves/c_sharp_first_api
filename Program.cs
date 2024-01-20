using Microsoft.OpenApi.Models;
using firstTestAPI.DB;


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

app.MapGet("/pizzas", () => PizzaDb.GetPizzas());
app.MapPost("/pizzas", (Pizza pizza) => PizzaDb.CreatePizza(pizza));
app.MapPut("/pizzas", (Pizza pizza) => PizzaDb.UpdatePizza(pizza));

app.MapGet("/pizzas/{id}", (int id) => PizzaDb.GetPizza(id));
app.MapDelete("/pizzas/{id}", (int id) => PizzaDb.RemovePizza(id));

app.Run();