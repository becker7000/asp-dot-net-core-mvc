namespace Devfolio.Services
{
    public class ServicioTransitorio
    {
        public ServicioTransitorio()
        {
            ObtenerGuid = Guid.NewGuid(); // Genera una cadena aleatoria
        }

        public Guid ObtenerGuid { get; private set; }
    }
}
