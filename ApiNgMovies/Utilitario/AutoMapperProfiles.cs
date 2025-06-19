using ApiNgMovies.DTOs.Actor;
using ApiNgMovies.DTOs.Genero;
using ApiNgMovies.Entidades;
using AutoMapper;
using NetTopologySuite.Geometries;

namespace ApiNgMovies.Utilitario
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles(GeometryFactory geometryFactory)
        {
            MapeoGenero();
            MapeoActor();
        }
        private void MapeoActor()
        {
            CreateMap<CrearActorDTO, Actor>()
                .ForMember(a => a.Imagen, opt => opt.Ignore());
            CreateMap<Actor, ActorDTO>();
        }

        private void MapeoGenero() {
            CreateMap<CrearGeneroDTO, Genero>();
            CreateMap<Genero, GeneroDTO>();
        }
    }
}
