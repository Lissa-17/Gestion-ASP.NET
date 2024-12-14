#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionHopital.models
{
    public class Consultation
    {
        public int Id { get; set; }                       
        public double Poids { get; set; }
        public double Hauteur { get; set; }
        public string Diagnostique { get; set; }
        // Change the format to date
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date_Consultation { get; set; }
        public Medecin Medecin { get; set; }
        public Patient Patient { get; set; }
        public int MedecinId { get; set; }    
        public string PatientCode { get; set; } 
        public string Details
        {
            get { return $"{MedecinId}-{PatientCode}-{Diagnostique}-{Date_Consultation}";}
        }
    }
}