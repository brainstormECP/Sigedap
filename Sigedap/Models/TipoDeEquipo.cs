using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Sigedap.Models
{
    [Table("TiposDeEquipos")]
    public class TipoDeEquipo
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<EquipoDañado> EquiposDañados { get; set; }

        public virtual ICollection<EquipoNuevo> EquiposNuevos { get; set; }

        public TipoDeEquipo()
        {
            EquiposDañados = new HashSet<EquipoDañado>();
            EquiposNuevos = new HashSet<EquipoNuevo>();
        }

    }
}

