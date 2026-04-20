using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppEF.Models;

namespace WebAppEF.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autores { get; set; }

        public virtual DbSet<Editorial> Editoriales { get; set; }

        public virtual DbSet<Genero> Generos { get; set; }

        public virtual DbSet<Ubicacion> Ubicaciones { get; set; }

        public virtual DbSet<Libro> Libros { get; set; }
    }
}
