namespace ApiNgMovies.Entidades
{
    public class PeliculaCine
    {
        public int PeliculaCineId { get; set; }
        public int PeliculaId { get; set; }
        public int CineId { get; set; }
        public Cine? Cine { get; set; }
        public Pelicula? Pelicula { get; set; }
    }
}
