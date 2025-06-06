using System.ComponentModel.DataAnnotations;
using ApiNgMovies.Validaciones;

namespace ApiNgMovies.DTOs
{
    public class CrearGeneroDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener {1} caracteres como maximo")]
        [PrimeraMayuscula]
        public required string Nombre { get; set; }
    }
}
