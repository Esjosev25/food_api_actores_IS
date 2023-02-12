using Akka.Actor;
using Food_API_akka.Modelos;

namespace Food_API_akka.Actores
{
  public class SushiActor : ReceiveActor
  {
    public SushiActor()
    {
      Receive<Sushi>(sushi =>
      {

        Console.WriteLine($"Tu orden de  {sushi.Name} tiene : {sushi.Calories} calorias");
      }

      );
    }
    protected override void PreStart() => Console.WriteLine($"Orden  de Sushi iniciada a las {DateTime.Now.ToString("h:mm:ss tt")}");

    protected override void PostStop() => Console.WriteLine($"Orden  de Sushi  finalizada de a las {DateTime.Now.ToString("h:mm:ss tt")}");
  }

}

