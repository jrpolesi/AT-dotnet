using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelApp.Models;
using TravelApp.Services;

namespace TravelApp.Pages.Pacotes;

public class IndexModel : PageModel
{
    private readonly IPacoteTuristicoService _pacoteTuristicoService;

    public IEnumerable<PacoteTuristico> Pacotes { get; set; } = [];

    public IndexModel(IPacoteTuristicoService pacoteTuristicoService)
    {
        _pacoteTuristicoService = pacoteTuristicoService;
    }

    public async Task OnGetAsync()
    {
        Pacotes = await _pacoteTuristicoService.GetAllPacotesTuristicoAsync();
    }
}

