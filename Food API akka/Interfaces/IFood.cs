namespace Food_API_akka.Interfaces
{
  public interface IFood
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int Calories { get; set; }
    public  void iniciarOrden();
    public  void finalizarOrden() ;
  }
}
