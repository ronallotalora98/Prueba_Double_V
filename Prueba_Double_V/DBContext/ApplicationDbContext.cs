using Microsoft.EntityFrameworkCore;
using Prueba_Double_V.Domain.Models;

namespace Prueba_Double_V.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


    }
}
