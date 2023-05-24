using System.ComponentModel.DataAnnotations;

namespace PIABackEnd.Entidades
{
    public class Cita
    {
        public int Id { get; set; }

        [Required]
        public string Fecha { get; set; }

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public int PacienteId { get; set; }

        public Paciente Paciente { get; set; }

     

    }
}
