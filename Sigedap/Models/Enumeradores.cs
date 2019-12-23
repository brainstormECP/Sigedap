using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sigedap.Models
{
	public enum Destino 
    {
		BajaTecnica = 0,
		Reparacion = 1,
	}

    public enum Estado 
    {
        NoAtendido = 0,
        Abierto = 1,
        Finalizado = 2,
    }
}
