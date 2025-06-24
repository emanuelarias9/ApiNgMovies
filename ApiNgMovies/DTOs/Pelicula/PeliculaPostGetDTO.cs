using ApiNgMovies.DTOs.Cine;
using ApiNgMovies.DTOs.Genero;

namespace ApiNgMovies.DTOs.Pelicula
{
    public class PeliculaPostGetDTO
    {
        public List<GeneroDTO> Generos { get; set; }= new List<GeneroDTO>();
        public List<CineDTO> Cines { get; set; } = new List<CineDTO>();
    }
}
