using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Sigedap.Helpers;

namespace Sigedap.Models
{
    [Table("ActasRecogidaEquipos")]
    public class ActaRecogidaEquipos
    {
        [Key]
        public int ExpedienteDictamenDeReclamacionId { get; set; }
        
        public virtual Expediente Expediente { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        public string NombreRepresentante { get; set; }

        [Required]
        [RegularExpression(@"\d{11}", ErrorMessage = "{0} debe ser de 11 dígitos")]
        [ValidarCi]
        [StringLength(11, ErrorMessage = "{0} no puede tener más de 11 dígitos")]
        [Display(Name = "Ci del representante")]
        public string CiRepresentante { get; set; }

        public string UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

    }
}

