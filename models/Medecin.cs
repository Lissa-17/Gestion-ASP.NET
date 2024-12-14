#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionHopital.models
{
    public class Medecin
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        
        public string Sexe { get; set; }
        public string  Telephone { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }
        public string Specialite { get; set; }

        //hide when doing migration
        public string Nom_Complet
        {
            get { return $"{Nom} {Prenom}"; }
        }        
    }
}