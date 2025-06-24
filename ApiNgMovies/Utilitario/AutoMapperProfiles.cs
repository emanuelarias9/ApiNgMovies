using ApiNgMovies.DTOs.Actor;
using ApiNgMovies.DTOs.Cine;
using ApiNgMovies.DTOs.Genero;
using ApiNgMovies.DTOs.Pelicula;
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
            MapeoCine(geometryFactory);
            MapeoPelicula();
        }

        private void MapeoPelicula()
        {
            CreateMap<CrearPeliculaDTO, Pelicula>()
                .ForMember(p => p.ImagenUrl, opt => opt.Ignore())
                .ForMember(p => p.PeliculaGeneros, dto => dto.MapFrom(x => x.GenerosIds!.Select(id => new PeliculaGenero { GeneroId = id })))
                .ForMember(p => p.PeliculaCines, dto => dto.MapFrom(x => x.CinesIds!.Select(id => new PeliculaCine { CineId = id })))
                .ForMember(p => p.PeliculaActores, dto => dto.MapFrom(x => x.Actores!.Select(actor => new PeliculaActor { ActorId = actor.Id,Personaje=actor.Personaje })));

            CreateMap<Pelicula, PeliculaDTO>();
        }

        private void MapeoCine(GeometryFactory geometryFactory)
        {
            CreateMap<Cine, CineDTO>()
                .ForMember(c => c.Latitud, opt => opt.MapFrom(c => c.Ubicacion.Y))
                .ForMember(c => c.Longitud, opt => opt.MapFrom(c => c.Ubicacion.X));
            CreateMap<CrearCineDTO, Cine>()
                .ForMember(c => c.Ubicacion, dto => dto.MapFrom(p => geometryFactory.CreatePoint(new Coordinate(p.Longitud, p.Latitud))));
            
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
