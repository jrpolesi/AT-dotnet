using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelApp.Models;
using TravelApp.Services;

namespace TravelApp.Pages.Reservas
{
    public class IndexModel : PageModel
    {
        private readonly IReservaService _reservaService;

        public IndexModel(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        public IList<Reserva> Reservas { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var reservas = await _reservaService.GetAllReservasAsync();
            Reservas = reservas.ToList();
        }
    }
}