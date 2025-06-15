using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelApp.Data;
using TravelApp.Models;
using TravelApp.Services;

namespace TravelApp.Pages.Pacotes;

public class CreatePacoteTuristicoModel : PageModel
{
    private readonly TravelAppContext _context;
    private readonly ICidadeDestinoService _cidadeDestinoService;
    private readonly IPacoteTuristicoService _pacoteTuristicoService;

    [BindProperty]
    public PacoteTuristico PacoteTuristico { get; set; } = new PacoteTuristico
    {
        DataInicio = DateTime.Now,
    };

    [BindProperty]
    [Required(ErrorMessage = "É necessário selecionar pelo menos um destino")]
    public List<int> SelectedDestinos { get; set; } = new();

    public MultiSelectList CidadesDestino { get; set; }

    public CreatePacoteTuristicoModel(
        TravelAppContext context,
        ICidadeDestinoService cidadeDestinoService,
        IPacoteTuristicoService pacoteTuristicoService)
    {
        _context = context;
        _cidadeDestinoService = cidadeDestinoService;
        _pacoteTuristicoService = pacoteTuristicoService;
    }

    public async Task OnGetAsync()
    {
        var cidades = await _cidadeDestinoService.GetAllCidadesDestinoAsync();
        CidadesDestino = new MultiSelectList(cidades, "Id", "Nome");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await OnGetAsync();
            return Page();
        }

        if (SelectedDestinos.Count != 0)
        {
            PacoteTuristico.Destinos = _context.Cidades.Where(c => SelectedDestinos.Contains(c.Id)).ToList();
        }

        await _pacoteTuristicoService.AddPacoteTuristicoAsync(PacoteTuristico);
        return RedirectToPage("/Pacotes/Index");
    }
}