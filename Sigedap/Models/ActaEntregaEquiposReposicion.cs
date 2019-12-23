using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Sigedap.Models
{
     [Table("ActasEntregaEquiposReposicion")]
    public class ActaEntregaEquiposReposicion
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int ExpedienteDictamenDeReclamacionId { get; set; }

        public virtual Expediente Expediente { get; set; }

        public virtual ICollection<EquipoDañado> EquiposDañados { get; set; }


        public string UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

    }
}

