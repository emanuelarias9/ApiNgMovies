namespace ApiNgMovies.DTOs.PeliculaActor
{
    public class PeliculaActorDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Imagen { get; set; }
        public string Personaje { get; set; } = null!;
        
    }
}
