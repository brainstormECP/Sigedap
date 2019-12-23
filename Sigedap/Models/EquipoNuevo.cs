using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Sigedap.Models
{
   
    [Table("EquiposNuevos")]
    public class EquipoNuevo
    {
        public int Id { get; set; }

        public int EquipoDañadoId { get; set; }

        public virtual EquipoDañado EquipoDañado { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Serie { get; set; }

        [Required]
        public string Prestaciones { get; set; }

        [Required]
        public string Sistema { get; set; }

        [Required]
        public string EntregadoPor { get; set; }

        [Required]
        public string Cargo { get; set; }

        public int MarcaId { get; set; }

        public virtual Marca Marca { get; set; }

        public int TipoDeEquipoId { get; set; }

        public virtual TipoDeEquipo TipoDeEquipo { get; set; }

        public int ActaEntregaEquiposReposicionId { get; set; }

        public virtual ActaEntregaEquiposReposicion ActaEntregaEquiposReposicion { get; set; }

    }
}

