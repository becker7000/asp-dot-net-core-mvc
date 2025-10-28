namespace Devfolio.Services
{
    public class ServicioUnico
    {
        public ServicioUnico()
        {
            ObtenerGuid = Guid.NewGuid(); // Genera una cadena aleatoria
        }

        public Guid ObtenerGuid { get; private set; }
    }
}
