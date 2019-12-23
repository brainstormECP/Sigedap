using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigedap.Models
{
    [Table("DictamenesPorPartes")]
    public class DictamenPorPartes
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        public string Defecto { get; set; }

        public int DictamenTecnicoEquipoDañadoId { get; set; }

        public virtual DictamenTecnico DictamenTecnico { get; set; }

    }
}

