using System.ComponentModel.DataAnnotations;

namespace ApiNgMovies.DTOs.Pelicula
{
    public class CrearPeliculaDTO
    {
        
        [Required]
        public required string Titulo { get; set; }
        public string? Trailer { get; set; }
        public DateTime FechaEstreno { get; set; }
        public IFormFile? ImagenUrl { get; set; }
    }
}
