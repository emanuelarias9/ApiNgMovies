using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace ApiNgMovies.Entidades
{
    public class Cine
    {
        public int Id { get; set; }
        [Required]
        public required string Nombre { get; set; }
        public required Point Ubicacion {get; set; }
    }
}
