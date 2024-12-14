#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionHopital.models;

namespace GestionHopital.Pages_Consultations
{
    public class DeleteModel : PageModel
    {
        private readonly GestionHopital.models.HopitalContext _context;

        public DeleteModel(GestionHopital.models.HopitalContext context)
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

            var consultation = await _context.Consultation.FirstOrDefaultAsync(m => m.Id == id);
            var medecin = await _context.Medecin.FirstOrDefaultAsync(m => m.Id == consultation.MedecinId);
            var patient = await _context.Patient.FirstOrDefaultAsync(m => m.Code == consultation.PatientCode);

            if (consultation == null)
            {
                return NotFound();
            }
            else
            {
                Consultation = consultation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultation = await _context.Consultation.FindAsync(id);
            if (consultation != null)
            {
                Consultation = consultation;
                _context.Consultation.Remove(Consultation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
