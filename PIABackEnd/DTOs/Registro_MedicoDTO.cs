using Newtonsoft.Json;
using PIABackEnd.Entidades;
using System.ComponentModel.DataAnnotations;

namespace PIABackEnd.DTOs
{
    public class Registro_MedicoDTO
    {
        public int Id { get; set; }

        [Required]
        public string Peso { get; set; }

        [Required]

        public string Altura { get; set; }

        public string Enfermedades { get; set; }

        public int PacienteId { get; set; }
        [JsonIgnore]
        public Paciente Paciente { get; set; }
    }
}
