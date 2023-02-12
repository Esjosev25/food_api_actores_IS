using Food_API_akka.Interfaces;

namespace Food_API_akka.Modelos
{
  public class Pizza : IFood
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int Calories { get; set; }
    //public int time
    public Pizza(string name, string description, int calories)
    {
      this.Name = name;
      this.Description = description;
      this.Calories = calories;

    }
    public void iniciarOrden() => Console.WriteLine($"Pizza en el horno {DateTime.Now.ToString("h: mm:ss tt")}");
    public void finalizarOrden() => Console.WriteLine($"Pizza sacada del horno {DateTime.Now.ToString("h: mm:ss tt")}");
  }
}
