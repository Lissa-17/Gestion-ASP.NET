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
    public class IndexModel : PageModel
    {
        private readonly GestionHopital.models.HopitalContext _context;

        public IndexModel(GestionHopital.models.HopitalContext context)
        {
            _context = context;
        }

        public IList<Prescription> Prescription { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Prescription = await _context.Prescription
            .Include(c => c.Consultation)
            .ToListAsync();
        }
    }
}
