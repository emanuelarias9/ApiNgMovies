using System.ComponentModel.DataAnnotations;
using ApiNgMovies.Validaciones;

namespace ApiNgMovies.Entidades
{
    public class Genero
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener {1} caracteres como maximo")]
        [PrimeraMayuscula]
        public required string Nombre { get; set; }
    }
}
