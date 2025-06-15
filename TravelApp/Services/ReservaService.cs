using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Models;

namespace TravelApp.Services;

public class ReservaService : IReservaService
{
  private readonly TravelAppContext _context;

  public ReservaService(TravelAppContext context)
  {
    _context = context;
  }

  public async Task<Reserva> AddReservaAsync(Reserva reserva)
  {
    _context.Reservas.Add(reserva);
    await _context.SaveChangesAsync();
    return reserva;
  }

  public async Task<IEnumerable<Reserva>> GetAllReservasAsync()
  {
    return await _context.Reservas
        .Include(r => r.Cliente)
        .Include(r => r.PacoteTuristico)
        .ToListAsync();
  }

  public async Task<Reserva?> GetReservaByIdAsync(int id)
  {
    return await _context.Reservas
        .Include(r => r.Cliente)
        .Include(r => r.PacoteTuristico)
        .FirstOrDefaultAsync(r => r.Id == id);
  }

  public async Task<Reserva> UpdateReservaAsync(Reserva reserva)
  {
    _context.Reservas.Update(reserva);
    await _context.SaveChangesAsync();
    return reserva;
  }

  public async Task DeleteReservaAsync(int id)
  {
    var reserva = await _context.Reservas.FindAsync(id);
    if (reserva != null)
    {
      _context.Reservas.Remove(reserva);
      await _context.SaveChangesAsync();
    }
  }
}