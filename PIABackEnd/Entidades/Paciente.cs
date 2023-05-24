using PIABackEnd.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace PIABackEnd.Entidades
{
    public class Paciente
    {
        public int Id { get; set; }

        [Required]
        [Upper1stLetter]
        public string Nombre { get; set; }

        [Required]
        [Upper1stLetter]
        public string Apellido { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefono { get; set; }

        public List<Cita> citas { get; set; }

 

        public List<Registro_Medico> registro_medicos { get; set; }

    }
}
