using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models;

public class PacoteTuristico
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O título é obrigatório")]
    [MinLength(10, ErrorMessage = "O título deve ter pelo menos 10 caracteres.")]
    public string Titulo { get; set; }
    
    [Required(ErrorMessage = "A data de início é obrigatória")]
    public DateTime DataInicio { get; set; }
    
    [Required(ErrorMessage = "A capacidade máxima é obrigatória")]
    [Range(1, 200, ErrorMessage = "A capacidade máxima deve ser entre 1 e 200.")]
    public int CapacidadeMaxima { get; set; }
    
    [Required(ErrorMessage = "O preço é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal Preco { get; set; }
    
    [Required(ErrorMessage = "É necessário selecionar pelo menos um destino")]
    public List<CidadeDestino> Destinos { get; set; } = [];
}