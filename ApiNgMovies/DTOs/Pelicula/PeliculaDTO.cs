using System.ComponentModel.DataAnnotations;

namespace ApiNgMovies.DTOs.Pelicula
{
    public class PeliculaDTO
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public string? Trailer { get; set; }
        public DateTime FechaEstreno { get; set; }
        public string? ImagenUrl { get; set; }
    }
}
