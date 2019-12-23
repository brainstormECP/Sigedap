using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sigedap.ViewModels
{
    public class ConfiguracionViewModel
    {
        [Required]
        public string Ueb { get; set; }
        
        [Required]
        [RegularExpression("\\d")]
        public string Codigo { get; set; }

        [Required]
        public string OficinaComercial { get; set; }


    }
}