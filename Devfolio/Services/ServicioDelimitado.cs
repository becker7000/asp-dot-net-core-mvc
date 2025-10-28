namespace Devfolio.Services
{
    public class ServicioDelimitado
    {
        public ServicioDelimitado()
        {
            ObtenerGuid = Guid.NewGuid(); // Genera una cadena aleatoria
        }

        public Guid ObtenerGuid { get; private set; }
    }
}
