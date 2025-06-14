using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelApp.Models;
using TravelApp.Services;

namespace TravelApp.Pages.Cidades;

public class IndexModel : PageModel
{
    private readonly ICidadeDestinoService _cidadeDestinoService;
    
    public IEnumerable<CidadeDestino> CidadesDestino { get; set; } = [];

    public IndexModel(ICidadeDestinoService cidadeDestinoService)
    {
        _cidadeDestinoService = cidadeDestinoService;
    }

    public async Task OnGetAsync()
    {
        CidadesDestino = await _cidadeDestinoService.GetAllCidadesDestinoAsync();
    }
}
