namespace ApiNgMovies.Entidades
{
    public class PeliculaActor
    {
        public int PeliculaActorId { get; set; }
        public int PeliculaId { get; set; }
        public int ActorId { get; set; }
        public int orden { get; set; }
        public required string Personaje { get; set; }
        public Actor? Actor { get; set; }
        public Pelicula? Pelicula { get; set; }
    }
}
