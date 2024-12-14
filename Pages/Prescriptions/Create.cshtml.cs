using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionHopital.models;

namespace GestionHopital.Pages_Prescriptions
{
    public class CreateModel : PageModel
    {
        private readonly GestionHopital.models.HopitalContext _context;

        public CreateModel(GestionHopital.models.HopitalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ConsultationId"] = new SelectList(_context.Set<Consultation>(), "Id", "Details");
            return Page();
        }

        [BindProperty]
        public Prescription Prescription { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Prescription.Add(Prescription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
