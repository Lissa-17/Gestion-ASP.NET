#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionHopital.models;

namespace GestionHopital.Pages_Prescriptions
{
    public class DetailsModel : PageModel
    {
        private readonly GestionHopital.models.HopitalContext _context;

        public DetailsModel(GestionHopital.models.HopitalContext context)
        {
            _context = context;
        }

        public Prescription Prescription { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription.FirstOrDefaultAsync(m => m.Id == id);
            var consultation = await _context.Consultation.FirstOrDefaultAsync(m => m.Id == prescription.ConsultationId);
            if (prescription == null)
            {
                return NotFound();
            }
            else
            {
                Prescription = prescription;
            }
            return Page();
        }
    }
}
