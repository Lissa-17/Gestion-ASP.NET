using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionHopital.models;

namespace GestionHopital.Pages_Consultations
{
    public class EditModel : PageModel
    {
        private readonly GestionHopital.models.HopitalContext _context;

        public EditModel(GestionHopital.models.HopitalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Consultation Consultation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation =  await _context.Consultation.FirstOrDefaultAsync(m => m.Id == id);
            if (consultation == null)
            {
                return NotFound();
            }
            Consultation = consultation;
           ViewData["MedecinId"] = new SelectList(_context.Medecin, "Id", "Nom_Complet");
           ViewData["PatientCode"] = new SelectList(_context.Patient, "Code", "Nom_Complet");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Consultation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultationExists(Consultation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ConsultationExists(int id)
        {
            return _context.Consultation.Any(e => e.Id == id);
        }
    }
}
