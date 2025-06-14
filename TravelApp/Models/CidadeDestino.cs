namespace TravelApp.Models;

public class CidadeDestino
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public int PaisDestinoId { get; set; }
    public PaisDestino PaisDestino { get; set; }
}