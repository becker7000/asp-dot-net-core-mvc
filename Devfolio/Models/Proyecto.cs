namespace Devfolio.Models
{
    public class Proyecto
    {
        // Atajo: prop + tab + tab (para crear propiedades)
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Tecnologias { get; set; } = string.Empty;
        public string Enlace { get; set; } = string.Empty;
        public bool Destacado { get; set; } = false;
        
    }

}
