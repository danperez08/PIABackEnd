﻿using PIABackEnd.Validaciones;
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

        public List<Cita> citas { get; set; }

    }
}
