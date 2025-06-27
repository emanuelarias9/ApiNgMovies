﻿using ApiNgMovies.DTOs.Pelicula;

namespace ApiNgMovies.DTOs
{
    public class LandingPageDTO
    {
        public List<PeliculaDTO> EnCines { get; set; } = new List<PeliculaDTO>();
        public List<PeliculaDTO> ProximosEstrenos { get; set; } = new List<PeliculaDTO>();
    }
}
