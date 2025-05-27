using ApiNgMovies.Entidades;

namespace ApiNgMovies
{
    public class Memoria
    {
        private List<Genero> _generos;

        public Memoria()
        {
            _generos = new List<Genero>
            {
                new Genero{ id= 1, Nombre= "Acción" },
                new Genero{ id= 2, Nombre= "Comedia" },
                new Genero{ id= 3, Nombre= "Drama" },
                new Genero{ id= 4, Nombre= "Terror" },
                new Genero{ id= 5, Nombre= "Ciencia Ficción" },
                new Genero{ id= 6, Nombre= "Romance" },
            };
        }

        public List<Genero> ListadoGeneros() { 
            return _generos;
        }

        public async Task<Genero?> ObtenerGeneroPorId(int id)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            return _generos.FirstOrDefault(genero => genero.id == id);
        }
        public async Task<Genero?> ObtenerGeneroPorNombre(string nombre)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            return _generos.FirstOrDefault(genero => genero.Nombre.ToLower().Equals(nombre.ToLower()));
        }
    }
}
