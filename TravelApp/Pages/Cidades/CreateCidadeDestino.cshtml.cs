using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelApp.Models;
using TravelApp.Services;

namespace TravelApp.Pages.Cidades;

public class CreateCidadeDestino : PageModel
{
    private readonly ICidadeDestinoService _cidadeDestinoService;
    private readonly IPaisDestinoService _paisDestinoService;

    [BindProperty]
    public CidadeDestino CidadeDestino { get; set; } = new();
    public List<SelectListItem> Paises { get; set; } = [];

    public CreateCidadeDestino(ICidadeDestinoService cidadeDestinoService, IPaisDestinoService paisDestinoService)
    {
        _cidadeDestinoService = cidadeDestinoService;
        _paisDestinoService = paisDestinoService;
    }

    public async Task OnGetAsync()
    {
        var paises = await _paisDestinoService.GetAllPaisesDestinoAsync();
        Paises = paises.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Nome }).ToList();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await OnGetAsync();
            return Page();
        }
        await _cidadeDestinoService.AddCidadeDestinoAsync(CidadeDestino);
        return RedirectToPage("./Index");
    }
}