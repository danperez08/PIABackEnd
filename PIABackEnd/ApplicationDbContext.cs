using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PIABackEnd.Entidades;

namespace PIABackEnd
{
    public class ApplicationDbContext: DbContext 
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { 

        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Cita> Citas { get; set; }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Registro_Medico> Registro_Medicos { get; set; }

     
    }
}
