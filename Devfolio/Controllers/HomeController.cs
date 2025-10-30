using Devfolio.Models;
using Devfolio.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Devfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorio; // Despu�s de ver DI

        // No son interfaces:
        private readonly ServicioTransitorio servicioTransitorio;
        private readonly ServicioDelimitado servicioDelimitado;
        private readonly ServicioUnico servicioUnico;
        private readonly IConfiguration configuration;
        private readonly IServicioGmail servicioGmail;

        public HomeController(
            ILogger<HomeController> logger, 
            IRepositorioProyectos repositorio,
            ServicioTransitorio servicioTransitorio,
            ServicioDelimitado servicioDelimitado,
            ServicioUnico servicioUnico,
            IConfiguration configuration,
            IServicioGmail servicioGmail
            ) // Los servicios van despu�s de ver servicios,
              // ctrl + . (para crear y asignar como un campo)
        {
            _logger = logger;
            this.repositorio = repositorio; // Se inicializa el repositorio
            this.servicioTransitorio = servicioTransitorio;
            this.servicioDelimitado = servicioDelimitado;
            this.servicioUnico = servicioUnico;
            this.configuration = configuration;
            this.servicioGmail = servicioGmail;
        }

        public IActionResult Index()
        {
            // Agreamos finalmente informaci�n sobre el desarrollador en el logger:
            var desarrollador = configuration.GetValue<string>("desarrollador");

            // Usando el logger:
            _logger.LogInformation("["+desarrollador+"] Hola a todos desde el logger de ASP.NET Core");

            // Todas las categor�as:
            _logger.LogTrace("[" + desarrollador + "] Mensaje de Trace");
            _logger.LogDebug("["+desarrollador+"] Mensaje de Debug");
            _logger.LogInformation("["+desarrollador+"] Mensaje de Information");
            _logger.LogWarning("["+desarrollador+"] Mensaje de Warning");
            _logger.LogError("["+desarrollador+"] Mensaje de Error");
            _logger.LogCritical("["+desarrollador+"] Mensaje de Critical");

            // Usando ViewBag 
            ViewBag.Bienvenida = "Bienvenidos a mi sitio web";
            ViewBag.Presentacion = "Soy un desarrollador full stack especialidado en C#, Python y Java.";
            ViewBag.Numero = 71;

            // Esto va antes de ver Inyecci�n de dependencias
            // Inyectamos el repositorio:
            // RepositorioProyectos repositorio = new RepositorioProyectos();

            // Usando un modelo fuertemente tipado
            var proyectos = repositorio.ObtenerProyectos();
            return View("Inicio", proyectos); // Tambi�n funcionar�a: return View(proyectos);

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

        // Acci�n para entregar la vista del formulario de Contacto
        // Por defecto usa el m�todo GET
        public IActionResult Contacto()
        {
            return View();
        }

        // Acci�n para manejar el formulario de contacto (sobrecarga):
        [HttpPost] // Idicamos que se usa el m�todo POST
        public async Task<IActionResult> Contacto(Contacto contacto) // ASINCRONA
        { // ASINCRONA
            _logger.LogInformation("Nombre: "+contacto.Nombre);
            _logger.LogInformation("Email: "+contacto.Email);
            _logger.LogInformation("Mensaje: "+contacto.Mensaje);

            // Aqu� va la l�gica de env�o de datos al Modelo...
            await servicioGmail.Enviar(contacto);

            // En vez de retornar una vista, se retorna una Action...
            // Probar enviando un email no v�lido...
            return RedirectToAction("Gracias"); // No ser�a correcto entregar otra vista debido a los modelos
        }

        public IActionResult Gracias()
        {
            return View();
        }

        public IActionResult Ajax()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            // Usando ViewData (tambi�n podemos marcar atributos de la clase como ViewData)
            ViewData["Privacidad"] = "Usa esta p�gina para detallar tu politica de privacidad de tu sitio.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
