using TravelApp.Models;

namespace TravelApp.Services;

public interface IClienteService
{
  Task<Cliente> AddClienteAsync(Cliente cliente);
  Task<IEnumerable<Cliente>> GetAllClientesAsync();
}