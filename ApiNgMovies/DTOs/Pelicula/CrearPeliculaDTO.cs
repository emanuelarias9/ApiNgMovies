using System.ComponentModel.DataAnnotations;
using ApiNgMovies.DTOs.PeliculaActor;
using ApiNgMovies.Utilitario;
using Microsoft.AspNetCore.Mvc;

namespace ApiNgMovies.DTOs.Pelicula
{
    public class CrearPeliculaDTO
    {
        
        [Required]
        public required string Titulo { get; set; }
        public string? Trailer { get; set; }
        public DateTime FechaEstreno { get; set; }
        public IFormFile? ImagenUrl { get; set; }

        [ModelBinder(BinderType =typeof(TypeBinder))]
        public List<int>? GenerosIds { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder))]
        public List<int>? CinesIds { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder))]
        public List<CrearPeliculaActorDTO>? Actores { get; set; }
    }
}
