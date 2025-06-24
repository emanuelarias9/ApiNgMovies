using System;
using ApiNgMovies.DTOs.Cine;
using ApiNgMovies.DTOs.Genero;
using ApiNgMovies.DTOs.Pelicula;
using ApiNgMovies.Entidades;
using ApiNgMovies.Servicios;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace ApiNgMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IOutputCacheStore outputCacheStore;
        private readonly IStorage storage;
        private const string cacheActorTag = "pelicula";
        private readonly string contenedor = "peliculas";

        public PeliculasController(AppDbContext context, IMapper mapper, IOutputCacheStore outputCacheStore, IStorage storage)
        {
            this.context = context;
            this.mapper = mapper;
            this.outputCacheStore = outputCacheStore;
            this.storage = storage;
        }

        [HttpGet("{id:int}", Name = "ObtenerPelicula")]
        public IActionResult Get(int id) {
        
            throw new NotImplementedException("This method is not implemented yet.");
        }

        [HttpGet("PostGet")]
        public async Task<ActionResult<PeliculaPostGetDTO>> PostGet() { 
        
            var cines = await context.Cine.ProjectTo<CineDTO>(mapper.ConfigurationProvider).ToListAsync();
            var generos = await context.Genero.ProjectTo<GeneroDTO>(mapper.ConfigurationProvider).ToListAsync();
            
            return Ok(new PeliculaPostGetDTO
            {
                Cines = cines,
                Generos = generos
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CrearPeliculaDTO crearPeliculaDTO) {

            var pelicula = mapper.Map<Pelicula>(crearPeliculaDTO);
            if (crearPeliculaDTO.ImagenUrl is not null)
            {
                var url = await storage.Save(contenedor, crearPeliculaDTO.ImagenUrl);
                pelicula.ImagenUrl = url;
            }

            SetOrdenActores(pelicula);

            context.Add(pelicula);

            await context.SaveChangesAsync();

            await outputCacheStore.EvictByTagAsync(cacheActorTag, default);

            var peliculaDTO = mapper.Map<PeliculaDTO>(pelicula);

            return CreatedAtRoute("ObtenerPelicula", new { id = pelicula.Id }, peliculaDTO);

        }

        private void SetOrdenActores(Pelicula pelicula)
        {
            if (pelicula.PeliculaActores is not null)
            {
                for (int i = 0; i < pelicula.PeliculaActores.Count; i++)
                {
                    pelicula.PeliculaActores[i].Orden = i;
                }
            }
            
        }

    }
}
