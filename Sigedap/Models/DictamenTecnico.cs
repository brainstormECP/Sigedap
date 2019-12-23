using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Sigedap.Models
{
    [Table("DictamenesTecnicos")]
    public class DictamenTecnico
    {
        [Key]
        public int EquipoDañadoId { get; set; }

        public virtual EquipoDañado EquipoDañado { get; set; }

        [Display(Name = "Número")]
        public int Numero { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        [Display(Name = "Primer Técnico")]
        public string Tecnico1 { get; set; }

        [Required]
        [Display(Name = "Segundo Técnico")]
        public virtual string Tecnico2 { get; set; }

        [Required]
        [Display(Name = "Tercer Técnico")]
        public virtual string Tecnico3 { get; set; }

        [Required]
        [Display(Name = "Recibido por")]
        public virtual string RecibidoPor { get; set; }

        public Destino Destino { get; set; }

        public virtual ICollection<DictamenPorPartes> DictamenesPorPartes { get; set; }

        public DictamenTecnico()
        {
            DictamenesPorPartes = new HashSet<DictamenPorPartes>();
        }

        public string UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

    }
}

