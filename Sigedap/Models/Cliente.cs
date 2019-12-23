using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Sigedap.Helpers;

namespace Sigedap.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"\d{11}", ErrorMessage = "{0} debe ser de 11 dígitos")]
        [Remote("ValidarCi", "Cliente", AdditionalFields = "Id")]
        [ValidarCi]
        [StringLength(11, ErrorMessage = "{0} no puede tener más de 11 dígitos")]
        [Display(Name = "Ci")]
        public string Ci { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }

        [Required]
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }

        [Required]
        public string Calle { get; set; }

        [Required]
        public int No { get; set; }

        public int? Piso { get; set; }

        public string Apto { get; set; }


        [Display(Name = "Primer Entrecalle")]
        public virtual string EntreCalle1 { get; set; }

        [Display(Name = "Segunda Entrecalle")]
        public string EntreCalle2 { get; set; }

        public string Rpto { get; set; }

        [Required]
        public string Municipio { get; set; }

        [Display(Name = "Teléfono particular")]
        public int? TelefonoParticular { get; set; }

        [Display(Name = "Teléfono del trabajo")]
        public int? TelefonoTrabajo { get; set; }

        [Required]
        public string Control { get; set; }

        public int Ruta { get; set; }

        [Required]
        public string Folio { get; set; }

        public virtual ICollection<DictamenDeReclamacion> DictamenDeReclamacion { get; set; }

        [NotMapped]
        [Display(Name = "Nombre")]
        public string NombreCompleto { get { return Nombres + " " + PrimerApellido + " " + SegundoApellido; } }

        [NotMapped]
        [Display(Name = "Dirección")]
        public string Direccion { get { return Calle + " #" + No + " Entre " + EntreCalle1 + " y " + EntreCalle2 + ". " + Municipio; } }

        public Cliente()
        {
            DictamenDeReclamacion = new HashSet<DictamenDeReclamacion>();
        }

    }
}

