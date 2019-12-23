using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Sigedap.Models
{
    public class Usuario : IdentityUser
    {
        public bool Activo { get; set; }

        public virtual ICollection<DictamenDeReclamacion> DictamenesDeReclamacion { get; set; }
        public virtual ICollection<ActaDevolucion> ActasDevoluciones { get; set; }
        public virtual ICollection<ActaEntregaEquiposReposicion> ActasEntregaEquiposReposicion { get; set; }
        public virtual ICollection<ActaRecogidaDestruir> ActasRecogidaDestruir { get; set; }
        public virtual ICollection<ActaRecogidaEquipos> ActasRecogidaEquipos { get; set; }
        public virtual ICollection<DictamenTecnico> DictamenesTecnicos { get; set; }
    }
}