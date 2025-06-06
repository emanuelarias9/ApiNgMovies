using ApiNgMovies.DTOs;
using ApiNgMovies.Entidades;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        public async Task<List<GeneroDTO>> Get()
        {
            return await context.Genero.ProjectTo<GeneroDTO>(mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("{id:int}", Name = "ObtenerGenero")]
        [OutputCache(Tags = [cacheGeneroTag])]
        public async Task<ActionResult<GeneroDTO>> Get(int id)
        {
            throw new NotImplementedException();
        }
        
        [HttpGet("{nombre}")]
        [OutputCache]
        public async Task<ActionResult<GeneroDTO>> Get(string nombre)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CrearGeneroDTO CrearGeneroDTO) 
        {
            var genero = mapper.Map<Genero>(CrearGeneroDTO);
            context.Add(genero);
            await context.SaveChangesAsync();
            return CreatedAtRoute("ObtenerGenero", new { id = genero.Id }, genero);
        }
    }
}
