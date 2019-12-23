using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Sigedap.Helpers;

namespace Sigedap.Models
{
    [Table("ActasDevoluciones")]
    public class ActaDevolucion
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        public string Representante { get; set; }

        [Required]
        [RegularExpression(@"\d{11}", ErrorMessage = "{0} debe ser de 11 dígitos")]
        [ValidarCi]
        [StringLength(11, ErrorMessage = "{0} no puede tener más de 11 dígitos")]
        [Display(Name = "Ci del representante")]
        public string CiRepresentante { get; set; }

        public int ExpedienteDictamenDeReclamacionId { get; set; }

        public virtual Expediente Expediente { get; set; }

        public string UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}

