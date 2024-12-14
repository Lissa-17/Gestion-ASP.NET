using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GestionHopital.models;

namespace GestionHopital.Pages_Medecins
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
            return Page();
        }

        [BindProperty]
        public Medecin Medecin { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Medecin.Add(Medecin);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
