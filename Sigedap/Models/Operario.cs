using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigedap.Models
{
    public class Operario : Trabajador
    {
        public virtual ICollection<Expediente> Expedientes { get; set; }

        public Operario()
        {
            Expedientes = new HashSet<Expediente>();
        }

    }
}

