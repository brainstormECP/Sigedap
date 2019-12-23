using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigedap.Models
{
    [Table("Expedientes")]
    public class Expediente
    {
        [Key]
        public int DictamenDeReclamacionId { get; set; }

        public virtual DictamenDeReclamacion DictamenDeReclamacion { get; set; }

        [Display(Name = "Número")]
        [Required]
        public string Numero { get; set; }

        [Display(Name = "Pagado hasta")]
        public DateTime PagadoHasta { get; set; }

        [Required]
        public string Causas { get; set; }

        [Required]
        [Display(Name = "Amparado por NT")]
        public string AmparadoPorNt { get; set; }

        [Display(Name = "Fecha de Afectación")]
        [DataType(DataType.Date)]
        public DateTime FechaAfectacion { get; set; }

        [Display(Name = "Fecha de normalización del servicio")]
        [DataType(DataType.Date)]
        public DateTime FechaDeNormalizacionServicio { get; set; }

        [Display(Name = "Fecha de recibido en la UEB Municipal")]
        [DataType(DataType.Date)]
        public DateTime FechaRecibidoUebMunicipal { get; set; }

        [Display(Name = "Fecha de visita del cliente")]
        [DataType(DataType.Date)]
        public DateTime FechaVisitaCliente { get; set; }

        [Display(Name = "Fecha del NT")]
        [DataType(DataType.Date)]
        public DateTime FechaNt { get; set; }

        public Estado Estado { get; set; }

        public string Observaciones { get; set; }

        public int OperarioId { get; set; }

        public virtual Operario Operario { get; set; }

        public int InspectorId { get; set; }

        public virtual Inspector Inspector { get; set; }

        public int DespachadorId { get; set; }

        public virtual Despachador Despachador { get; set; }

        public virtual ICollection<EquipoDañado> EquiposDañados { get; set; }

        public virtual ActaRecogidaEquipos ActaRecogidaEquipos { get; set; }

        public virtual SolicitudReposicion SolicitudReposicion { get; set; }

        public virtual ActaDevolucion ActaDevolucion { get; set; }

        public virtual ICollection<ActaRecogidaDestruir> ActasRecogidaDestruir { get; set; }

        public virtual ICollection<ActaEntregaEquiposReposicion> ActasEntregaEquiposReposicion { get; set; }

        public Expediente()
        {
            EquiposDañados = new HashSet<EquipoDañado>();
            ActasRecogidaDestruir = new HashSet<ActaRecogidaDestruir>();
            ActasEntregaEquiposReposicion = new HashSet<ActaEntregaEquiposReposicion>();
        }

    }
}

