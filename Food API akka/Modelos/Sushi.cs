using Food_API_akka.Interfaces;

namespace Food_API_akka.Modelos
{
  public class Sushi : IFood
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int Calories { get; set; }
    //public int time
    public Sushi(string name, string description, int calories)
    {
      this.Name = name;
      this.Description = description;
      this.Calories = calories;

    }
    public void iniciarOrden() => Console.WriteLine("El chef está elaborando tu sushi");
    public void finalizarOrden() => Console.WriteLine("sushi terminao");
  }
}
