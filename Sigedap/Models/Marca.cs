using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Sigedap.Models
{
    [Table("Marcas")]
    public class Marca
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<EquipoDañado> EquiposDañados { get; set; }

        public virtual ICollection<EquipoNuevo> EquiposNuevos { get; set; }

        public Marca()
        {
            EquiposDañados = new HashSet<EquipoDañado>();
            EquiposNuevos = new HashSet<EquipoNuevo>();
        }

    }
}

