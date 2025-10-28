using Devfolio.Models;
using Devfolio.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Devfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorio; // Después de ver DI

        // No son interfaces:
        private readonly ServicioTransitorio servicioTransitorio;
        private readonly ServicioDelimitado servicioDelimitado;
        private readonly ServicioUnico servicioUnico;

        public HomeController(
            ILogger<HomeController> logger, 
            IRepositorioProyectos repositorio,
            ServicioTransitorio servicioTransitorio,
            ServicioDelimitado servicioDelimitado,
            ServicioUnico servicioUnico
            ) // Los servicios van después de ver servicios,
              // ctrl + . (para crear y asignar como un campo)
        {
            _logger = logger;
            this.repositorio = repositorio; // Se inicializa el repositorio
            this.servicioTransitorio = servicioTransitorio;
            this.servicioDelimitado = servicioDelimitado;
            this.servicioUnico = servicioUnico;
        }

        public IActionResult Index()
        {

            // Usando el logger:
            _logger.LogInformation("Hola a todos desde el logger de ASP.NET Core");

            // Todas las categorías:
            _logger.LogTrace("Mensaje de Trace");
            _logger.LogDebug("Mensaje de Debug");
            _logger.LogInformation("Mensaje de Information");
            _logger.LogWarning("Mensaje de Warning");
            _logger.LogError("Mensaje de Error");
            _logger.LogCritical("Mensaje de Critical");

            // Usando ViewBag 
            ViewBag.Bienvenida = "Bienvenidos a mi sitio web";
            ViewBag.Presentacion = "Soy un desarrollador full stack especialidado en C#, Python y Java.";
            ViewBag.Numero = 71;

            // Esto va antes de ver Inyección de dependencias
            // Inyectamos el repositorio:
            // RepositorioProyectos repositorio = new RepositorioProyectos();

            // Usando un modelo fuertemente tipado
            var proyectos = repositorio.ObtenerProyectos();
            return View("Inicio", proyectos); // También funcionaría: return View(proyectos);

        }

        public IActionResult Guids()
        {
            var guidViewModel = new GuidViewModel()
            {
                GuidTransitorio = servicioTransitorio.ObtenerGuid,
                GuidDelimitado = servicioDelimitado.ObtenerGuid,
                GuidUnico = servicioUnico.ObtenerGuid
            };
            return View(guidViewModel);
        }

        public IActionResult Privacy()
        {
            // Usando ViewData (también podemos marcar atributos de la clase como ViewData)
            ViewData["Privacidad"] = "Usa esta página para detallar tu politica de privacidad de tu sitio.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
