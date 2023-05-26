using Microsoft.AspNetCore.Identity;
using PIABackEnd.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace PIABackEnd.Entidades
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required]
        [Upper1stLetter]
        public string Nombre { get; set; }

        [Required]
        [Upper1stLetter]
        public string Apellido { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<Cita> Citas { get; set; }

        // Relación con el usuario (administrador)
        /*public IdentityUser User { get; set; }*/
       

    }
}
