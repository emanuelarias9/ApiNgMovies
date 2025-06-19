using System.ComponentModel.DataAnnotations;

namespace ApiNgMovies.DTOs.Cine
{
    public class CrearCineDTO
    {
        [Required]
        public required string Nombre { get; set; }
        [Range(-90, 90, ErrorMessage = "La latitud debe estar entre -90 y 90 grados.")]
        public double Latitud { get; set; }
        [Range(-180, 180, ErrorMessage = "La longitud debe estar entre -180 y 180 grados.")]
        public double Longitud { get; set; }
    }
}
