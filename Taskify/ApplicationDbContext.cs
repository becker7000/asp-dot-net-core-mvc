using Microsoft.EntityFrameworkCore;
using Taskify.Entities; // Usando EF Core

namespace Taskify
{
    // Configuraciones de la base de datos, tablas y campos (queries)
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        // Con esto indicamos que Tarea es una Entidad (es como suscribirla)
        public DbSet<Tarea> Tareas { get; set; }

        // Una migración es un paso intemedio 

    }
}
