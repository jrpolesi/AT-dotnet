using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Models;

namespace TravelApp.Services;

public class ReservaService : IReservaService
{
    private readonly TravelAppContext _context;
    private readonly IPacoteTuristicoService _pacoteTuristicoService;

    public ReservaService(TravelAppContext context, IPacoteTuristicoService pacoteTuristicoService)
    {
        _context = context;
        _pacoteTuristicoService = pacoteTuristicoService;
    }

    public async Task<Reserva> AddReservaAsync(Reserva reserva)
    {
        await ValidateReservaAsync(reserva);
        _context.Reservas.Add(reserva);
        await _context.SaveChangesAsync();
        return reserva;
    }

    public async Task<IEnumerable<Reserva>> GetAllReservasAsync()
    {
        return await _context.Reservas
            .Include(r => r.Cliente)
            .Include(r => r.PacoteTuristico)
            .Where(r => !r.IsDeleted)
            .ToListAsync();
    }

    public async Task<Reserva?> GetReservaByIdAsync(int id)
    {
        return await _context.Reservas
            .Include(r => r.Cliente)
            .Include(r => r.PacoteTuristico)
            .Where(r => !r.IsDeleted)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Reserva> UpdateReservaAsync(Reserva reserva)
    {
        await ValidateReservaAsync(reserva);
        _context.Reservas.Update(reserva);
        await _context.SaveChangesAsync();
        return reserva;
    }

    public async Task DeleteReservaAsync(int id)
    {
        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva != null)
        {
            reserva.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }

    private async Task<bool> HasDuplicateReservationAsync(Reserva reserva)
    {
        return await _context.Reservas
            .AnyAsync(r => r.ClienteId == reserva.ClienteId &&
                           r.PacoteTuristicoId == reserva.PacoteTuristicoId &&
                           r.DataReserva.Date == reserva.DataReserva.Date &&
                           r.Id != reserva.Id
            );
    }

    private async Task<bool> IsPackageFullAsync(Reserva reserva)
    {
        var existingReserva = await _context.Reservas
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == reserva.Id && r.PacoteTuristicoId == reserva.PacoteTuristicoId);

        if (existingReserva?.PacoteTuristicoId == reserva.PacoteTuristicoId)
        {
            return false;
        }

        var availablePacotes = await _pacoteTuristicoService.GetAvailablePacotesTuristicoAsync();
        var isAvailable = availablePacotes.Any(p => p.Id == reserva.PacoteTuristicoId);
        return !isAvailable;
    }

    private async Task<bool> IsValidPackageDateAsync(Reserva reserva)
    {
        var pacote = await _pacoteTuristicoService.GetPacoteTuristicoByIdAsync(reserva.PacoteTuristicoId);
        if (pacote == null) return false;

        return pacote.DataInicio > DateTime.Now;
    }

    private async Task ValidateReservaAsync(Reserva reserva)
    {
        if (await HasDuplicateReservationAsync(reserva))
        {
            throw new InvalidOperationException("Já existe uma reserva para este cliente neste pacote túristico e data.");
        }

        if (!await IsValidPackageDateAsync(reserva))
        {
            throw new InvalidOperationException("A data do pacote turístico não pode ser anterior à data atual.");
        }

        if (await IsPackageFullAsync(reserva))
        {
            throw new InvalidOperationException("O pacote turístico já está lotado.");
        }
    }
}