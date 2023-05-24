using PIABackEnd.Entidades;
using PIABackEnd.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace PIABackEnd.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }

        [Required]
        [Upper1stLetter]
        public string Nombre { get; set; }

        [Required]
        [Upper1stLetter]
        public string Apellido { get; set; }

        public List<Cita> CitasDTO { get; set; }
    }
}
