using Microsoft.EntityFrameworkCore;
using TravelApp.Models;
using TravelApp.Data;

namespace TravelApp.Services
{
    public class PacoteTuristicoService : IPacoteTuristicoService
    {
        private readonly TravelAppContext _context;

        public PacoteTuristicoService(TravelAppContext context)
        {
            _context = context;
        }

        public async Task<PacoteTuristico> AddPacoteTuristicoAsync(PacoteTuristico pacote)
        {
            _context.PacotesTuristicos.Add(pacote);
            await _context.SaveChangesAsync();
            return pacote;
        }

        public async Task<IEnumerable<PacoteTuristico>> GetAllPacotesTuristicoAsync()
        {
            return await _context.PacotesTuristicos
                .Include(p => p.Destinos)
                .ToListAsync();
        }

        public async Task<PacoteTuristico?> GetPacoteTuristicoByIdAsync(int id)
        {
            return await _context.PacotesTuristicos
                .Include(p => p.Destinos)
                .ThenInclude(d => d.PaisDestino)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<PacoteTuristico>> GetAvailablePacotesTuristicoAsync()
        {
            return await _context.PacotesTuristicos
                .Include(p => p.Destinos)
                .Where(p => p.DataInicio > DateTime.Now)
                .Where(p => _context.Reservas.Count(r => r.PacoteTuristicoId == p.Id) < p.CapacidadeMaxima)
                .ToListAsync();
        }
    }
}