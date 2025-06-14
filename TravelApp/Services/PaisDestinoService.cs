using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Models;

namespace TravelApp.Services;

public class PaisDestinoService : IPaisDestinoService
{
    private readonly TravelAppContext _context;
    
    public PaisDestinoService(TravelAppContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PaisDestino>> GetAllPaisesDestinoAsync()
    {
        return await _context.Paises.ToListAsync();
    }

    public async Task<PaisDestino> AddPaisDestinoAsync(PaisDestino paisDestino)
    {
        _context.Paises.Add(paisDestino);
        await _context.SaveChangesAsync();
        return paisDestino;
    }
}
