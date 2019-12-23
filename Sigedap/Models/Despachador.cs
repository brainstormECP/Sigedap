using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigedap.Models
{
	
	public class Despachador : Trabajador
	{
		public virtual ICollection<Expediente> Expedientes{get;set;}

	    public Despachador()
	    {
	        Expedientes = new HashSet<Expediente>();
	    }

	}
}

