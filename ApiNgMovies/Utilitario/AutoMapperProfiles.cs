using ApiNgMovies.DTOs;
using ApiNgMovies.Entidades;
using AutoMapper;

namespace ApiNgMovies.Utilitario
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            MapeoGenero();
        }

        private void MapeoGenero() {
            CreateMap<CrearGeneroDTO, Genero>();
            CreateMap<Genero, GeneroDTO>();
        }
    }
}
