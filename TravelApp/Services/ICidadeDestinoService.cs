using TravelApp.Models;

namespace TravelApp.Services;

public interface ICidadeDestinoService
{
    Task<CidadeDestino> AddCidadeDestinoAsync(CidadeDestino cidadeDestino);
    Task<IEnumerable<CidadeDestino>> GetAllCidadesDestinoAsync();
}
