using Azure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PIABackEnd.Entidades;

namespace PIABackEnd
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Cita> Citas { get; set; }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Registro_Medico> Registro_Medicos { get; set; }


     
    }
}
