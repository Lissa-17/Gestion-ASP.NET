using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionHopital.models;

namespace GestionHopital.Pages_Consultations
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
        ViewData["MedecinId"] = new SelectList(_context.Medecin, "Id", "Nom_Complet");
        ViewData["PatientCode"] = new SelectList(_context.Patient, "Code", "Nom_Complet");
            return Page();
        }

        [BindProperty]
        public Consultation Consultation { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Consultation.Add(Consultation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
