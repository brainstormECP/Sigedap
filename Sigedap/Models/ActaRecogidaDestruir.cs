using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Sigedap.Models
{
     [Table("ActasRecogidaDestruir")]
    public class ActaRecogidaDestruir
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        public string Testigo2 { get; set; }

        [Required]
        public string Testigo1 { get; set; }

        [Required]
        public string Testigo3 { get; set; }

        public DateTime FechaDestruccion { get; set; }

        public DateTime FechaEntregaAlmacen { get; set; }

        [Required]
        public string RecibidoPor { get; set; }

        public int ExpedienteDictamenDeReclamacionId { get; set; }

        public virtual Expediente Expediente { get; set; }

        public virtual ICollection<EquipoDañado> EquiposDañados { get; set; }

        public string UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

    }
}

