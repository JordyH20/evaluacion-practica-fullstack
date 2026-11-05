using Microsoft.EntityFrameworkCore;
using PruebaFullStack.Models;

namespace PruebaFullStack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
    }
}
