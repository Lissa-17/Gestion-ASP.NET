#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionHopital.models
{
    public class Prescription
    {        
        public int Id { get; set; }        
        public string prescription { get; set; }
        // hide before doing migration
        public int ConsultationId { get; set; }
        public Consultation Consultation { get; set; }
    }
}