using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelApp.Models;
using TravelApp.Services;

namespace TravelApp.Pages.Reservas
{
    public class DetailsModel : PageModel
    {
        private readonly IReservaService _reservaService;

        public DetailsModel(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        public Reserva Reserva { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _reservaService.GetReservaByIdAsync(id.Value);

            if (reserva is not null)
            {
                Reserva = reserva;
                return Page();
            }

            return NotFound();
        }
    }
}