#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionHopital.models;

namespace GestionHopital.Pages_Patients
{
    public class IndexModel : PageModel
    {
        private readonly GestionHopital.models.HopitalContext _context;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IndexModel(GestionHopital.models.HopitalContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; } = default!;

        public async Task OnGetAsync(string searchTerm)
        {
            SearchTerm = searchTerm;
            if(!string.IsNullOrEmpty(SearchTerm))
            {
                Patient = await _context.Patient.Where(p => p.Nom.Contains(SearchTerm) || p.Prenom.Contains(SearchTerm)).ToListAsync();
            }
            else
            {
                Patient = await _context.Patient.ToListAsync();
            }            
            // Patient = await _context.Patient.ToListAsync();
        }
    }
}
