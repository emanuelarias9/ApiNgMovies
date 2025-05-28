using ApiNgMovies.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace ApiNgMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        [HttpGet]
        [OutputCache]
        public List<Genero> Get()
        {
            var repositorio = new Memoria();
            var generos= repositorio.ListadoGeneros();
            return generos;
        }

        [HttpGet("{id:int}")]
        [OutputCache]
        public async Task<ActionResult<Genero>> Get(int id)
        {
            var repositorio = new Memoria();
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
            var repositorio = new Memoria();
            var genero = await repositorio.ObtenerGeneroPorNombre(nombre);
            if (genero is null)
            {
                return NotFound();
            }
            return genero;
        }

        [HttpPost]
        public void Post([FromBody] Genero genero) 
        {

        }
    }
}
