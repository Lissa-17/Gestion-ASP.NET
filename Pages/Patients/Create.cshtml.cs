using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionHopital.models;

namespace GestionHopital.Pages_Patients
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
        public Patient Patient { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //generate code for the patient using the first 3 letters of the first name and the first 3 letters of the last name + a random 4 digit number
            Random rand = new Random();
            string code = Patient.Nom.Substring(0, 3) + Patient.Prenom.Substring(0, 3) + rand.Next(1000, 9999).ToString();
            Patient.Code = code;

            _context.Patient.Add(Patient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
