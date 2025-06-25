using ApiNgMovies.DTOs;
using ApiNgMovies.DTOs.Actor;
using ApiNgMovies.DTOs.PeliculaActor;
using ApiNgMovies.Entidades;
using ApiNgMovies.Servicios;
using ApiNgMovies.Utilitario;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace ApiNgMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IOutputCacheStore outputCacheStore;
        private readonly IStorage storage;
        private const string cacheActorTag = "actor";
        private readonly string contenedor = "actores";

        public ActoresController(AppDbContext context, IMapper mapper, IOutputCacheStore outputCacheStore,IStorage storage)
        {
            this.context = context;
            this.mapper = mapper;
            this.outputCacheStore = outputCacheStore;
            this.storage = storage;
        }

        [HttpGet]
        [OutputCache(Tags = [cacheActorTag])]
        public async Task<List<ActorDTO>> Get([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = context.Actor;
            await HttpContext.ParametrosPaginacion(queryable);
            return await queryable.OrderBy(a=>a.Nombre)
                .Paginar(paginacion)
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("{id:int}", Name = "ObtenerActor")]
        [OutputCache(Tags = [cacheActorTag])]
        public async Task<ActionResult<ActorDTO>> Get(int id)
        {
            var actor = await context.Actor
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (actor is null)
            {
                return NotFound();
            }

            return Ok(actor);
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<List<PeliculaActorDTO>>> Get(string nombre)
        {
            var peliculasActor = await context.Actor
                .Where(pa => pa.Nombre.Contains(nombre))
                .OrderBy(pa => pa.Nombre)
                .ProjectTo<PeliculaActorDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
            if (peliculasActor.Count == 0)
            {
                return NotFound();
            }
            return Ok(peliculasActor);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CrearActorDTO crearActorDTO)
        {
            var actor = mapper.Map<Actor>(crearActorDTO);

            if (crearActorDTO.Imagen is not null)
            {
                actor.Imagen = await storage.Save(contenedor, crearActorDTO.Imagen);

            }

            context.Actor.Add(actor);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheActorTag,default);
            return CreatedAtRoute("ObtenerActor", new { id = actor.Id }, actor);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromForm] CrearActorDTO crearActorDTO) 
        { 
        
            var actor = await context.Actor.FirstOrDefaultAsync(a => a.Id == id);
            if (actor is null)
            {
                return NotFound();
            }

            actor = mapper.Map(crearActorDTO, actor);
            if (crearActorDTO.Imagen is not null)
            {
                actor.Imagen = await storage.Update(actor.Imagen, contenedor, crearActorDTO.Imagen);
            }
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheActorTag, default);
            return Ok(actor);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedRecords = await context.Actor.Where(a => a.Id == id).ExecuteDeleteAsync();

            if (deletedRecords == 0)
            {
                return NotFound();
            }

            await outputCacheStore.EvictByTagAsync(cacheActorTag, default);
            return Ok();
        }

    }
}
