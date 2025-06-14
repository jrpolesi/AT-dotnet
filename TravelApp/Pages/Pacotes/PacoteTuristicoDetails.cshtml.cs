using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelApp.Data;
using TravelApp.Models;
using TravelApp.Services;

namespace TravelApp.Pages.Pacotes;

public class PacoteTuristicoDetailsModel : PageModel
{
    private readonly IPacoteTuristicoService _pacoteTuristicoService;

    public PacoteTuristicoDetailsModel(TravelAppContext context, IPacoteTuristicoService pacoteTuristicoService)
    {
        _pacoteTuristicoService = pacoteTuristicoService;
    }

    public PacoteTuristico PacoteTuristico { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        PacoteTuristico = await _pacoteTuristicoService.GetPacoteTuristicoByIdAsync(id);
        if (PacoteTuristico == null)
        {
            return NotFound();
        }

        return Page();
    }
}