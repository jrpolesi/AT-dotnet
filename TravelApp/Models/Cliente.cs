using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models;

public class Cliente
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress(ErrorMessage = "O email informado não é válido")]
    [StringLength(150, ErrorMessage = "O email deve ter no máximo 150 caracteres")]
    public string Email { get; set; } = string.Empty;

    public List<Reserva> Reservas { get; set; } = [];
}