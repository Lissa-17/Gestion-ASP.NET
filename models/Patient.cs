#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionHopital.models
{
    public class Patient
    {
        [Key]
        public string Code { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public string Telephone {get; set; }
        public string Adresse { get; set; } 
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]       
        public DateTime Date_enregistrement { get; set; }

        // hide when doing migration
        public string Nom_Complet
        {
            get { return $"{Nom} {Prenom}"; }
        }
    }
}