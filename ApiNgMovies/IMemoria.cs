using ApiNgMovies.Entidades;

namespace ApiNgMovies
{
    public interface IMemoria
    {
        List<Genero> ListadoGeneros();
        Task<Genero?> ObtenerGeneroPorId(int id);
        bool Existe(string nombre);
        Task<Genero?> ObtenerGeneroPorNombre(string nombre);
        void Crear(Genero genero);
    }
}
