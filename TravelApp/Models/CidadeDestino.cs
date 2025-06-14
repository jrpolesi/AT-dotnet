using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models;

public class CidadeDestino
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O país é obrigatório")]
    public int PaisDestinoId { get; set; }
    public PaisDestino? PaisDestino { get; set; }

    public List<PacoteTuristico> PacotesTuristicos { get; set; } = [];
}