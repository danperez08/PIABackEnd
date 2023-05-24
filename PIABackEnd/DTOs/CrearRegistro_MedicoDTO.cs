using PIABackEnd.Entidades;
using System.ComponentModel.DataAnnotations;

namespace PIABackEnd.DTOs
{
    public class CrearRegistro_MedicoDTO
    {
        public int Id { get; set; }

        [Required]
        public string Peso { get; set; }

        [Required]

        public string Altura { get; set; }

        public string Enfermedades { get; set; }

   
    }
}
