using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionHopital.models
{
    public class HopitalContext:IdentityDbContext
    {
        public DbSet<Consultation> Consultation { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Medecin> Medecin { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<AppUser> AppUser {get; set;}

        public HopitalContext(DbContextOptions<HopitalContext> options) : base(options)
        {            
        }
    }
}