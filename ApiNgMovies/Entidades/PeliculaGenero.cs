namespace ApiNgMovies.Entidades
{
    public class PeliculaGenero
    {
        public int PeliculaGeneroId { get; set; }
        public int GeneroId { get; set; }
        public int PeliculaId { get; set; }
        public Genero? Genero { get; set; }
        public Pelicula? Pelicula { get; set; }
    }
}
