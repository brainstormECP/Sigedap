using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web.Script.Serialization;

namespace Sigedap.Models
{
    [Table("EquiposDañados")]
    public class EquipoDañado
    {
        public int Id { get; set; }

        public int ExpedienteDictamenDeReclamacionId { get; set; }
        
        public virtual Expediente ExpedienteDictamenDeReclamacion { get; set; }

        public int TipoDeEquipoId { get; set; }

        public virtual TipoDeEquipo TipoDeEquipo { get; set; }

        public virtual EquipoNuevo EquipoNuevo { get; set; }

        [Required]
        public string Nacionalidad { get; set; }

        [Required]
        public string Serie { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public int MarcaId { get; set; }

        public virtual Marca Marca { get; set; }

        public virtual DictamenTecnico DictamenTecnico { get; set; }

        public int? ActasRecogidaDestruirId { get; set; }

        public virtual ActaRecogidaDestruir ActasRecogidaDestruir { get; set; }

        public int? ActaEntregaEquiposReposicionId { get; set; }

        public virtual ActaEntregaEquiposReposicion ActaEntregaEquiposReposicion { get; set; }

    }
}

