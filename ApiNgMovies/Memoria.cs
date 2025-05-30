using ApiNgMovies.Entidades;

namespace ApiNgMovies
{
    public class Memoria : IMemoria
    {
        private List<Genero> _generos;

        public Memoria()
        {
            _generos = new List<Genero>
            {
                new Genero{ Id= 1, Nombre= "Acción" },
                new Genero{ Id= 2, Nombre= "Comedia" },
                new Genero{ Id= 3, Nombre= "Drama" },
                new Genero{ Id= 4, Nombre= "Terror" },
                new Genero{ Id= 5, Nombre= "Ciencia Ficción" },
                new Genero{ Id= 6, Nombre= "Romance" },
            };
        }

        public List<Genero> ListadoGeneros() { 
            return _generos;
        }

        public async Task<Genero?> ObtenerGeneroPorId(int id)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            return _generos.FirstOrDefault(genero => genero.Id == id);
        }

        public bool Existe(string nombre) 
        { 
            return _generos.Any(genero => genero.Nombre == nombre);
        }

        public async Task<Genero?> ObtenerGeneroPorNombre(string nombre)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            return _generos.FirstOrDefault(genero => genero.Nombre.ToLower().Equals(nombre.ToLower()));
        }
    }
}
