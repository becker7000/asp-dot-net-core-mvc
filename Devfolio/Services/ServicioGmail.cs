using Devfolio.Models;
using System.Net;
using System.Net.Mail;

namespace Devfolio.Services
{
    // Extraemos su interfaz
    public class ServicioGmail : IServicioGmail
    {
        private readonly IConfiguration configuration;

        public ServicioGmail
        (
            IConfiguration configuration
        )
        {
            this.configuration = configuration;
        }

        // Programación asíncrona:
        public async Task Enviar(Contacto contacto)
        {
            // ESTOS DOS PRIMEROS DATOS DEBEN SER SECRETOS:
            var emailEmisor = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
            // Este password se puede ocultar
            var password = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");

            // ESTOS DOS DATOS PUEDEN SER PUBLICOS:
            var host = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
            var puerto = configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PUERTO");

            // 
            var smtpCliente = new SmtpClient(host, puerto);
            smtpCliente.EnableSsl = true; // Forma segura
            smtpCliente.UseDefaultCredentials = false; // No usar credenciales

            smtpCliente.Credentials = new NetworkCredential(emailEmisor, password);

            // Yo me estoy mandando un mensaje a mi mismo, por eso emisor 2 veces:
            var mensaje = new MailMessage(emailEmisor, emailEmisor,
                $"El cliente {contacto.Nombre} con email '{contacto.Email}' quiere contactarte.",contacto.Mensaje);

            await smtpCliente.SendMailAsync(mensaje);


        }

    }
}
