using Akka.Actor;
using Food_API_akka.Modelos;
using Food_API_akka.Actores;
using Food_API_akka.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var system = ActorSystem.Create("FoodAPI");

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
  var forecast = Enumerable.Range(1, 5).Select(index =>
      new WeatherForecast
      (
          DateTime.Now.AddDays(index),
          Random.Shared.Next(-20, 55),
          summaries[Random.Shared.Next(summaries.Length)]
      ))
      .ToArray();
  return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/food", async () =>
{
  var pizzaActor = system.ActorOf<PizzaActor>("Pizza");
  var hawaiana = new Pizza("Hawaiiana", "Pizza q a nadie le gusta", 500);

  hawaiana.iniciarOrden();
  pizzaActor.Tell(hawaiana);
  await pizzaActor.GracefulStop(TimeSpan.FromSeconds(5));

  Console.WriteLine("------------------------");
  var sushiActor = system.ActorOf<SushiActor>("Sushi");
  var japon = new Sushi("Japon", "Sushi con cangrejo y chipotle", 250);

  japon.iniciarOrden();
  sushiActor.Tell(japon);
  await sushiActor.GracefulStop(TimeSpan.FromSeconds(5));

  var list = new List<IFood> {
                japon,
                hawaiana
            };

  return Results.Ok(list);
});
app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}