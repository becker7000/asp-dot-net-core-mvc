using Devfolio.Models;

namespace Devfolio.Services
{
    public interface IServicioGmail
    {
        Task Enviar(Contacto contacto);
    }
}