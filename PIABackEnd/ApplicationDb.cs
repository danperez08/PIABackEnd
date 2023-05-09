using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PIABackEnd.Entidades;

namespace PIABackEnd
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }

    }
}
