using Akka.Actor;
using Food_API_akka.Modelos;

namespace Food_API_akka.Actores
{
  public class PizzaActor : ReceiveActor
  {
    public PizzaActor()
    {
      Receive<Pizza>(pizza =>
      {

        Console.WriteLine($"Tu pizza: {pizza.Name} tiene : {pizza.Calories} calorias");

      }
      );

    }
    protected override void PreStart() => Console.WriteLine($"Orden  de piiza iniciada a las {DateTime.Now.ToString("h:mm:ss tt")}");

    protected override void PostStop() => Console.WriteLine($"Orden de pizza finalizada de a las {DateTime.Now.ToString("h:mm:ss tt")}");

  }
}
