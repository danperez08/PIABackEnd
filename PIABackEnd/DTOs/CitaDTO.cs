using Newtonsoft.Json;
using PIABackEnd.Entidades;
using System.ComponentModel.DataAnnotations;

namespace PIABackEnd.DTOs
{
    public class CitaDTO
    {
        public int Id { get; set; }

        [Required]
        public string Fecha { get; set; }

        public int DoctorId { get; set; }
        
        public int PacienteId { get; set; }
        [JsonIgnore]
        
         public Doctor Doctor { get; set; }
        public Paciente Paciente { get; set; }
       
       
    }
}
