namespace Prueba_Double_V.Domain.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Email { get; set;}
        public string TipoIdentificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string NumeroIdentificacionConcatenado { get; set; }
        public string NombresApellidosConcatenado { get; set; }
        //public List<Usuario> Usuarios { get; set; }


    }
}
