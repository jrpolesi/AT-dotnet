using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelApp.Models;
using TravelApp.Services;

namespace TravelApp.Pages.Paises;

public class CreatePaisDestinoModel : PageModel
{
    private readonly IPaisDestinoService _paisDestinoService;

    [BindProperty]
    public PaisDestino PaisDestino { get; set; } = new();

    public CreatePaisDestinoModel(IPaisDestinoService paisDestinoService)
    {
        _paisDestinoService = paisDestinoService;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        await _paisDestinoService.AddPaisDestinoAsync(PaisDestino);
        return RedirectToPage("/Cidades");
    }
}

