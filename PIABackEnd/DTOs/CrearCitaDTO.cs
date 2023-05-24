using System.ComponentModel.DataAnnotations;

namespace PIABackEnd.DTOs
{
    public class CrearCitaDTO
    {
        public int Id { get; set; }

        [Required]
        public string Fecha { get; set; }
    }
}
