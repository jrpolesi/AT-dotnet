using TravelApp.Models;

namespace TravelApp.Services;

public interface IReservaService
{
  Task<Reserva> AddReservaAsync(Reserva reserva);
  Task<IEnumerable<Reserva>> GetAllReservasAsync();
  Task<Reserva?> GetReservaByIdAsync(int id);
  Task<Reserva> UpdateReservaAsync(Reserva reserva);
  Task DeleteReservaAsync(int id);
}