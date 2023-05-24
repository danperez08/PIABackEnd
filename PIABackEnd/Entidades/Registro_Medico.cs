using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PIABackEnd.Entidades
{
  
    public class Registro_Medico
    {
       
        public int Id { get; set; }

        [Required]
        public string Peso { get; set; }

        [Required]

        public string Altura { get; set; }

        public string Enfermedades { get; set; }

        public int PacienteId { get; set; }

        public Paciente Paciente { get; set; } 
    }
}
