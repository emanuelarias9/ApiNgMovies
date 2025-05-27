using ApiNgMovies.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace ApiNgMovies.Controllers
{
    [Route("api/[controller]")]
    public class GenerosController : ControllerBase
    {
        [HttpGet]
        public List<Genero> Get()
        {
            var repositorio = new Memoria();
            var generos= repositorio.ListadoGeneros();
            return generos;
        }

        [HttpGet("{id:int}")]
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
    }
}
