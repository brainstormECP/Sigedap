using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigedap.Models
{
	
	public class Inspector : Trabajador
	{
		public virtual ICollection<Expediente> Expedientes{get;set;}

	    public Inspector()
	    {
	        Expedientes = new HashSet<Expediente>();
	    }

	}
}

