using ApiNgMovies.DTOs;
using ApiNgMovies.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace ApiNgMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IOutputCacheStore outputCacheStore;
        private readonly AppDbContext context;
        private const string cacheGeneroTag = "genero";

        public GenerosController(IOutputCacheStore outputCacheStore, AppDbContext context)
        {
            this.outputCacheStore = outputCacheStore;
            this.context = context;
        }

        [HttpGet]
        [OutputCache(Tags = [cacheGeneroTag])]
        public List<GeneroDTO> Get()
        {
            return new List<GeneroDTO>() { 
                new GeneroDTO{ Id= 1, Nombre= "Acción" },
                new GeneroDTO{ Id= 2, Nombre= "Comedia" },
                new GeneroDTO{ Id= 3, Nombre= "Terror" }
            };
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
            var genero = new Genero
            {
                Nombre = CrearGeneroDTO.Nombre
            };
            context.Add(genero);
            await context.SaveChangesAsync();
            return CreatedAtRoute("ObtenerGenero", new { id = genero.Id }, genero);
        }
    }
}
