using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ApiNgMovies.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        [Required]
        public required string Titulo { get; set; } 
        public string? Trailer { get; set; } 
        public DateTime FechaEstreno { get; set; }
        [Unicode(false)]
        public string? ImagenUrl { get; set; }
        public List<PeliculaCine> PeliculaCines { get; set; } = new List<PeliculaCine>();
        public List<PeliculaActor> PeliculaActores { get; set; } = new List<PeliculaActor>();
        public List<PeliculaGenero> PeliculaGeneros { get; set; } = new List<PeliculaGenero>();
        
    }
}
