using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigedap.Models
{
    [Table("Trabajadores")]
    public class Trabajador
    {
        public int Id { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }

        public bool Activo { get; set; }

        [NotMapped]
        public string NombreCompleto { get { return Nombres + " " + Apellidos; } }

    }
}

