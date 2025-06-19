using System.ComponentModel.DataAnnotations;

namespace ApiNgMovies.DTOs.Cine
{
    public class CineDTO
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
