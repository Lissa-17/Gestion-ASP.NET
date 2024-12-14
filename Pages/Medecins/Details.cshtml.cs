using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionHopital.models;

namespace GestionHopital.Pages_Medecins
{
    public class DetailsModel : PageModel
    {
        private readonly GestionHopital.models.HopitalContext _context;

        public DetailsModel(GestionHopital.models.HopitalContext context)
        {
            _context = context;
        }

        public Medecin Medecin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medecin = await _context.Medecin.FirstOrDefaultAsync(m => m.Id == id);
            if (medecin == null)
            {
                return NotFound();
            }
            else
            {
                Medecin = medecin;
            }
            return Page();
        }
    }
}
