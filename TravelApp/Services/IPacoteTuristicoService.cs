using TravelApp.Models;

namespace TravelApp.Services
{
    public interface IPacoteTuristicoService
    {
        Task<PacoteTuristico> AddPacoteTuristicoAsync(PacoteTuristico pacote);
        Task<IEnumerable<PacoteTuristico>> GetAllPacotesTuristicoAsync();
        Task<PacoteTuristico?> GetPacoteTuristicoByIdAsync(int id);
        Task<IEnumerable<PacoteTuristico>> GetAvailablePacotesTuristicoAsync();
    }
}
