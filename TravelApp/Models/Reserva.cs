using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models;

public class Reserva
{
    public int Id { get; set; }

    [Display(Name = "Cliente")]
    [Required(ErrorMessage = "O cliente é obrigatório.")]
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }

    [Display(Name = "Pacote Turístico")]
    [Required(ErrorMessage = "O pacote turístico é obrigatório.")]
    public int PacoteTuristicoId { get; set; }
    public PacoteTuristico? PacoteTuristico { get; set; }

    [Display(Name = "Data da Reserva")]
    public DateTime DataReserva { get; set; }
}