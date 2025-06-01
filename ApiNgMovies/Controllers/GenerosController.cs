using ApiNgMovies.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace ApiNgMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IMemoria repositorio;
        private readonly IOutputCacheStore outputCacheStore;
        private readonly IConfiguration configuration;
        private const string cacheGeneroTag = "genero";
        public GenerosController(IMemoria repositorio,IOutputCacheStore outputCacheStore,IConfiguration configuration)
        {
            this.repositorio = repositorio;
            this.outputCacheStore = outputCacheStore;
            this.configuration = configuration;
        }

        [HttpGet("conexion")]
        public string GetConexion()
        {
            return configuration.GetValue<string>("Conexion")!;
        }

        [HttpGet]
        [OutputCache(Tags = [cacheGeneroTag])]
        public List<Genero> Get()
        {
            var generos= repositorio.ListadoGeneros();
            return generos;
        }

        [HttpGet("{id:int}")]
        [OutputCache(Tags = [cacheGeneroTag])]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            var genero = await repositorio.ObtenerGeneroPorId(id);
            if (genero is null) {
                return NotFound();
            }
            return genero;
        }
        
        [HttpGet("{nombre}")]
        [OutputCache]
        public async Task<ActionResult<Genero>> Get(string nombre)
        {
            var genero = await repositorio.ObtenerGeneroPorNombre(nombre);
            if (genero is null)
            {
                return NotFound();
            }
            return genero;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Genero genero) 
        {
            var existe = repositorio.Existe(genero.Nombre);
            if (existe)
            {
                return BadRequest($"Ya existe un genero con el nombre {genero.Nombre}");
            }

            repositorio.Crear(genero);
            await outputCacheStore.EvictByTagAsync(cacheGeneroTag, default);
            return Ok();
        }
    }
}
