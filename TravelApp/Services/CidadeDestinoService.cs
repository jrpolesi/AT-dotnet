using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Models;

namespace TravelApp.Services;

public class CidadeDestinoService : ICidadeDestinoService
{
    private readonly TravelAppContext _context;

    public CidadeDestinoService(TravelAppContext context)
    {
        _context = context;
    }

    public async Task<CidadeDestino> AddCidadeDestinoAsync(CidadeDestino cidadeDestino)
    {
        _context.Cidades.Add(cidadeDestino);
        await _context.SaveChangesAsync();
        return cidadeDestino;
    }

    public async Task<IEnumerable<CidadeDestino>> GetAllCidadesDestinoAsync()
    {
        return await _context.Cidades.Include(c => c.PaisDestino).ToListAsync();
    }
}