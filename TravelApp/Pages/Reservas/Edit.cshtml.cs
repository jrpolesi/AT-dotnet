using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelApp.Models;
using TravelApp.Services;

namespace TravelApp.Pages.Reservas;

public class EditModel : PageModel
{
    private readonly IReservaService _reservaService;
    private readonly IPacoteTuristicoService _pacoteTuristicoService;
    private readonly IClienteService _clienteService;

    public EditModel(
        IReservaService reservaService,
        IPacoteTuristicoService pacoteTuristicoService,
        IClienteService clienteService)
    {
        _reservaService = reservaService;
        _pacoteTuristicoService = pacoteTuristicoService;
        _clienteService = clienteService;
    }

    [BindProperty] public Reserva Reserva { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var reserva = await _reservaService.GetReservaByIdAsync(id.Value);
        if (reserva == null)
        {
            return NotFound();
        }

        Reserva = reserva;

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

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await OnGetAsync(Reserva.Id);
            return Page();
        }

        try
        {
            await _reservaService.UpdateReservaAsync(Reserva);
            return RedirectToPage("./Index");
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError("", ex.Message);
            await OnGetAsync(Reserva.Id);
            return Page();
        }
    }
}