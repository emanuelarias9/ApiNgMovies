using ApiNgMovies.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiNgMovies
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        public DbSet<Genero> Genero { get; set; }
    }
}
