using System.ComponentModel.DataAnnotations;

namespace ApiNgMovies.Entidades
{
    public class Genero
    {
        public int id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public required string Nombre { get; set; }
    }
}
