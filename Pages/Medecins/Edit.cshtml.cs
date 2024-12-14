using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionHopital.models;

namespace GestionHopital.Pages_Medecins
{
    public class EditModel : PageModel
    {
        private readonly GestionHopital.models.HopitalContext _context;

        public EditModel(GestionHopital.models.HopitalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Medecin Medecin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medecin =  await _context.Medecin.FirstOrDefaultAsync(m => m.Id == id);
            if (medecin == null)
            {
                return NotFound();
            }
            Medecin = medecin;
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

            _context.Attach(Medecin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedecinExists(Medecin.Id))
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

        private bool MedecinExists(int id)
        {
            return _context.Medecin.Any(e => e.Id == id);
        }
    }
}
