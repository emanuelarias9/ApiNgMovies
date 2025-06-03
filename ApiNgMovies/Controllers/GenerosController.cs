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
        public List<Genero> Get()
        {
            return new List<Genero>() { 
                new Genero{ Id= 1, Nombre= "Acción" },
                new Genero{ Id= 2, Nombre= "Comedia" },
                new Genero{ Id= 3, Nombre= "Terror" }
            };
        }

        [HttpGet("{id:int}", Name = "ObtenerGenero")]
        [OutputCache(Tags = [cacheGeneroTag])]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            throw new NotImplementedException();
        }
        
        [HttpGet("{nombre}")]
        [OutputCache]
        public async Task<ActionResult<Genero>> Get(string nombre)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Genero genero) 
        {
            context.Add(genero);
            await context.SaveChangesAsync();
            return CreatedAtRoute("ObtenerGenero", new { id = genero.Id }, genero);
        }
    }
}
