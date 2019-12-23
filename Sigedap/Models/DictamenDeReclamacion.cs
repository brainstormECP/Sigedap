using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using Sigedap.Helpers;

namespace Sigedap.Models
{
    [Table("DictamenesDeReclamacion")]
    public class DictamenDeReclamacion
    {
        public int Id { get; set; }

        [Display(Name = "UEB")]
        public string Ueb { get; set; }

        [Display(Name = "Oficina Comercial")]
        public string OficinaComercial { get; set; }

        public bool Procede { get; set; }

        public Estado Estado { get; set; }

        public string Observaciones { get; set; }

        [Display(Name = "Revisado Por")]
        public string RevisadoPor { get; set; }

        [Display(Name = "Autorizado Por")]
        public string AutorizadoPor { get; set; }

        [Display(Name = "Fecha de notificación al cliente")]
        public DateTime FechaNotificacionAlCliente { get; set; }

        [Display(Name = "Nombre del reclamante")]
        public string NombreReclamante { get; set; }

        [Required]
        [RegularExpression(@"\d{11}", ErrorMessage = "{0} debe ser de 11 dígitos")]
        [ValidarCi]
        [StringLength(11, ErrorMessage = "{0} no puede tener más de 11 dígitos")]
        [Display(Name = "CI del Reclamante")]
        public string CiReclamante { get; set; }

        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
       
        public virtual Expediente Expediente { get; set; }

        public string UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

    }
}

