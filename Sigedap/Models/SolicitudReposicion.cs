using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Sigedap.Models
{
    [Table("SolicitudesReposicion")]
    public class SolicitudReposicion
    {
        [Key]
        public int ExpedienteDictamenDeReclamacionId { get; set; }

        public virtual Expediente Expediente { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        public string Especialista { get; set; }
    }
}

