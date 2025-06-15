using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelApp.Models;
using TravelApp.Services;

namespace TravelApp.Pages.Reservas;

public class CreateModel : PageModel
{
    private readonly IReservaService _reservaService;
    private readonly IPacoteTuristicoService _pacoteTuristicoService;
    private readonly IClienteService _clienteService;

    public CreateModel(
        IReservaService reservaService,
        IPacoteTuristicoService pacoteTuristicoService,
        IClienteService clienteService)
    {
        _reservaService = reservaService;
        _pacoteTuristicoService = pacoteTuristicoService;
        _clienteService = clienteService;
    }

    [BindProperty] public Reserva Reserva { get; set; } = new Reserva { DataReserva = DateTime.Today };

    public async Task OnGetAsync()
    {
        var pacotes = await _pacoteTuristicoService.GetAvailablePacotesTuristicoAsync();
        ViewData["PacoteTuristicoId"] = pacotes.Select(p => new SelectListItem
        {
            Value = p.Id.ToString(),
            Text = p.Titulo + " - " + p.DataInicio.ToString("dd/MM/yyyy")
        }).ToList();

        var clientes = await _clienteService.GetAllClientesAsync();
        ViewData["ClienteId"] = clientes.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Nome
        }).ToList();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await OnGetAsync();
            return Page();
        }

        try
        {
            await _reservaService.AddReservaAsync(Reserva);
            return RedirectToPage("./Index");
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError("", ex.Message);
            await OnGetAsync();
            return Page();
        }
    }
}