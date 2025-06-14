using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Models;

namespace TravelApp.Services;

public class ClienteService : IClienteService
{
    private readonly TravelAppContext _context;

    public ClienteService(TravelAppContext context)
    {
        _context = context;
    }

    public async Task<Cliente> AddClienteAsync(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
    {
        return await _context.Clientes.ToListAsync();
    }
}