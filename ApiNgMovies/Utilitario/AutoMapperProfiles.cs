using ApiNgMovies.DTOs.Actor;
using ApiNgMovies.DTOs.Genero;
using ApiNgMovies.Entidades;
using AutoMapper;

namespace ApiNgMovies.Utilitario
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            MapeoGenero();
            MapeoActor();
        }
        private void MapeoActor()
        {
            CreateMap<CrearActorDTO, Actor>()
                .ForMember(a => a.Imagen, opt => opt.Ignore());
        }

        private void MapeoGenero() {
            CreateMap<CrearGeneroDTO, Genero>();
            CreateMap<Genero, ActorDTO>();
        }
    }
}
