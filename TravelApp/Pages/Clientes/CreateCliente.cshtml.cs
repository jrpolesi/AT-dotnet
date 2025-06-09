using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelApp.Models;
using TravelApp.Services;

namespace TravelApp.Pages.Clientes;

public class CreateClienteModel : PageModel
{
    private readonly IClienteService _clienteService;

    [BindProperty]
    public Cliente Cliente { get; set; } = new();

    public CreateClienteModel(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _clienteService.AddClienteAsync(Cliente);
        return RedirectToPage("./Index");
    }
}