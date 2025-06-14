using TravelApp.Models;

namespace TravelApp.Services;

public interface IPaisDestinoService
{
    Task<IEnumerable<PaisDestino>> GetAllPaisesDestinoAsync();
    Task<PaisDestino> AddPaisDestinoAsync(PaisDestino paisDestino);
}
