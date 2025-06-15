using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelApp.Data;
using TravelApp.Models;

namespace TravelApp.Pages.Reservas
{
    public class CreateModel : PageModel
    {
        private readonly TravelApp.Data.TravelAppContext _context;

        public CreateModel(TravelApp.Data.TravelAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Email");
        ViewData["PacoteTuristicoId"] = new SelectList(_context.PacotesTuristicos, "Id", "Titulo");
            return Page();
        }

        [BindProperty]
        public Reserva Reserva { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reservas.Add(Reserva);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
