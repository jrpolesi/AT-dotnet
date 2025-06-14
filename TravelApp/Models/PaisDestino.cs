using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models;

public class PaisDestino
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome é obrigatório")]
    [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres.")]
    public string Nome { get; set; }

    public List<CidadeDestino> Cidades { get; set; } = [];
}