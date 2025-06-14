using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelApp.Models;
using TravelApp.Services;

namespace TravelApp.Pages.Clientes;

public class IndexModel : PageModel
{
    private readonly IClienteService _clienteService;

    public IEnumerable<Cliente> Clientes { get; set; } = [];

    public IndexModel(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    public async Task OnGetAsync()
    {
        Clientes = await _clienteService.GetAllClientesAsync();
    }
}