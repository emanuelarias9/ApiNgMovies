﻿using ApiNgMovies.DTOs;
using ApiNgMovies.DTOs.Genero;
using ApiNgMovies.Entidades;
using ApiNgMovies.Utilitario;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace ApiNgMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private const string cacheGeneroTag = "genero";

        public GenerosController(IOutputCacheStore outputCacheStore, AppDbContext context,IMapper mapper)
        {
            this.outputCacheStore = outputCacheStore;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [OutputCache(Tags = [cacheGeneroTag])]
        public async Task<List<GeneroDTO>> Get([FromQuery] PaginacionDTO paginacion)
        {
            await HttpContext.ParametrosPaginacion(context.Genero);
            return await context.Genero
                .OrderBy(g => g.Nombre)
                .Paginar(paginacion)
                .ProjectTo<GeneroDTO>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("{id:int}", Name = "ObtenerGenero")]
        [OutputCache(Tags = [cacheGeneroTag])]
        public async Task<ActionResult<GeneroDTO>> Get(int id)
        {
            var genero = await context.Genero
                .ProjectTo<GeneroDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(g=>g.Id == id);
            if (genero is null)
            {
                return NotFound();
            }

            return Ok(genero);
        }
        
        [HttpGet("{nombre}")]
        [OutputCache]
        public async Task<ActionResult<GeneroDTO>> Get(string nombre)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CrearGeneroDTO crearGeneroDTO) 
        {
            var genero = mapper.Map<Genero>(crearGeneroDTO);
            context.Add(genero);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheGeneroTag, default);
            return CreatedAtRoute("ObtenerGenero", new { id = genero.Id }, genero);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] CrearGeneroDTO crearGeneroDTO)
        {
            var existeGenero = await context.Genero.AnyAsync(g=>g.Id==id);
            if (!existeGenero)
            {
                return NotFound();
            }
            var genero = mapper.Map<Genero>(crearGeneroDTO);
            genero.Id = id;
            context.Update(genero);
            await context.SaveChangesAsync();
            await outputCacheStore.EvictByTagAsync(cacheGeneroTag, default);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedRecords = await context.Genero.Where(g => g.Id == id).ExecuteDeleteAsync();

            if (deletedRecords==0)
            {
                return NotFound();
            }

            await outputCacheStore.EvictByTagAsync(cacheGeneroTag, default);
            return Ok();
        }
    }
}
