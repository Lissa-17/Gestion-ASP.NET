#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionHopital.models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionHopital.Pages_Medecins
{
    public class IndexModel : PageModel
    {
        private readonly GestionHopital.models.HopitalContext _context;
        public SelectList Specialties { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectedSpecialty { get; set; }

        public IndexModel(GestionHopital.models.HopitalContext context)
        {
            _context = context;
        }

        public IList<Medecin> Medecin { get;set; } = default!;

        public async Task OnGetAsync(string selectedSpecialty)
        {
            SelectedSpecialty = selectedSpecialty;
            var allSpecialites = new List<SelectListItem>
            {
                // new SelectListItem { Value = "", Text = "--Filtrer par specialite--"}, 
                new SelectListItem { Value = "Pédiatrie", Text = "Pédiatrie"}, 
                new SelectListItem { Value = "Cardiologie", Text = "Cardiologie"}, 
                new SelectListItem { Value = "Dermatologie", Text = "Dermatologie"}, 
                new SelectListItem { Value = "Neurologie", Text = "Neurologie"}, 
                new SelectListItem { Value = "Chirurgie", Text = "Chirurgie"},                 
                new SelectListItem { Value = "Oncologie", Text = "Oncologie"},                 
                new SelectListItem { Value = "Gynécologie-obstétrique", Text = "Gynécologie-obstétrique"},                 
                new SelectListItem { Value = "Médecin interne", Text = "Médecin interne"},                                                                 
                new SelectListItem { Value = "Orthopédie", Text = "Orthopédie"},                                                                 
                new SelectListItem { Value = "Ophtalmologie", Text = "Ophtalmologie"},                                                                 
                new SelectListItem { Value = "Oto-rhino-laryngologie(ORL)", Text = "Oto-rhino-laryngologie"},                                                                 
                new SelectListItem { Value = "Psychiatrie", Text = "Psychiatrie"},                                                                 
                new SelectListItem { Value = "Radiologie", Text = "Radiologie"},                                                                 
                new SelectListItem { Value = "Anesthésiologie", Text = "Anesthésiologie"},                                                                                                                                 
                new SelectListItem { Value = "Médecin d'urgence", Text = "Médecin d'urgence"},                                                                                                                                 
                new SelectListItem { Value = "Médecin du sport", Text = "Médecin du sport"}
            };
            Specialties = new SelectList(allSpecialites, "Value", "Text", selectedSpecialty);

            Medecin = await _context.Medecin.ToListAsync();
        }
    }
}
