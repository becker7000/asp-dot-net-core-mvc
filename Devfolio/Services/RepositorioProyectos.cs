using Devfolio.Models;

namespace Devfolio.Services
{
    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<Proyecto> ObtenerProyectos()
        {
            // Primero crear estos proyectos directamente en el controller
            return new List<Proyecto>
            {
                new Proyecto
                {
                    Nombre = "Landing page Devfolio",
                    Descripcion = "Página para mostrar mis proyectos y habilidades.",
                    Tecnologias = "ASP.NET Core, Bootstrap, C#.",
                    Enlace = "https://github.com/",
                    Destacado = true
                },
                new Proyecto
                {
                    Nombre = "API de tareas",
                    Descripcion = "API RESTful para gestionar tareas pendientes.",
                    Tecnologias = "ASP.NET Core, Entity Framework, C#.",
                    Enlace = "https://github.com/",
                    Destacado = false
                }

            };

        }
    }
}
