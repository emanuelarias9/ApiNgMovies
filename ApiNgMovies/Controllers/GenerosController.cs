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
        private const string cacheGeneroTag = "genero";
        public GenerosController(IOutputCacheStore outputCacheStore)
        {
            this.outputCacheStore = outputCacheStore;
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

        [HttpGet("{id:int}")]
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
            throw new NotImplementedException();
        }
    }
}
