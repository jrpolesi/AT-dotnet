using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelApp.Data;
using TravelApp.Models;

namespace TravelApp.Pages.Reservas
{
    public class DetailsModel : PageModel
    {
        private readonly TravelApp.Data.TravelAppContext _context;

        public DetailsModel(TravelApp.Data.TravelAppContext context)
        {
            _context = context;
        }

        public Reserva Reserva { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FirstOrDefaultAsync(m => m.Id == id);

            if (reserva is not null)
            {
                Reserva = reserva;

                return Page();
            }

            return NotFound();
        }
    }
}
