using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Sigedap.Models;

namespace Sigedap.ViewModels
{
    public class ReclamacionViewModel
    {
        public Cliente Cliente { get; set; }

        public DictamenDeReclamacion DictamenDeReclamacion { get; set; }
    }
}
