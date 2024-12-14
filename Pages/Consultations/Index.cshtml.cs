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
    public class IndexModel : PageModel
    {
        private readonly GestionHopital.models.HopitalContext _context;    

        public IndexModel(GestionHopital.models.HopitalContext context)
        {
            _context = context;
        }

        public IList<Consultation> Consultation { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(string PatientCode)
        {
            
            if(!string.IsNullOrEmpty(PatientCode))
            {
                Consultation = await _context.Consultation
                .Include(c => c.Medecin)
                .Include(c => c.Patient).Where(c => c.PatientCode == PatientCode).ToListAsync();
                return Page();
            }
            else
            {
                Consultation = await _context.Consultation
                .Include(c => c.Medecin)
                .Include(c => c.Patient).ToListAsync();     
                return Page();           
            }
            
        }
    }
}
