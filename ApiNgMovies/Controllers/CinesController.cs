using ApiNgMovies.DTOs;
using ApiNgMovies.DTOs.Cine;
using ApiNgMovies.DTOs.Genero;
using ApiNgMovies.Entidades;
using ApiNgMovies.Utilitario;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace ApiNgMovies.Controllers
{
    public class CinesController : ControllerBase

    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IOutputCacheStore outputCacheStore;
        private const string cacheCineTag = "cines";

        public CinesController(AppDbContext context, IMapper mapper, IOutputCacheStore outputCacheStore)
        {
            this.context = context;
            this.mapper = mapper;
            this.outputCacheStore = outputCacheStore;
        }

        [HttpGet]
        [OutputCache(Tags = [cacheCineTag])]
        public async Task<List<CineDTO>> Get([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = context.Actor;
            await HttpContext.ParametrosPaginacion(queryable);
            return await queryable.OrderBy(a => a.Nombre)
                .Paginar(paginacion)
                .ProjectTo<CineDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("{id:int}", Name = "ObtenerCine")]
        [OutputCache(Tags = [cacheCineTag])]
        public async Task<ActionResult<CineDTO>> Get(int id)
        {
            var cine = await context.Cine
                .ProjectTo<CineDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (cine is null)
            {
                return NotFound();
            }

            return Ok(cine);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CrearCineDTO crearCineDTO)
        {
            var cine = mapper.Map<Cine>(crearCineDTO);
            context.Add(cine);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheCineTag, default);
            return CreatedAtRoute("ObtenerCine", new { id = cine.Id }, cine);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] CrearCineDTO crearCineDTO)
        {
            var existeCine = await context.Genero.AnyAsync(g => g.Id == id);
            if (!existeCine)
            {
                return NotFound();
            }
            var cine = mapper.Map<Cine>(crearCineDTO);
            cine.Id = id;
            context.Update(cine);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheCineTag, default);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedRecords = await context.Cine.Where(c => c.Id == id).ExecuteDeleteAsync();

            if (deletedRecords == 0)
            {
                return NotFound();
            }

            await outputCacheStore.EvictByTagAsync(cacheCineTag, default);
            return Ok();
        }
    }
}
