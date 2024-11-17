using Microsoft.EntityFrameworkCore;

namespace fala_cidadao.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Problema> Problemas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
