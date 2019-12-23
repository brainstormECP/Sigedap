using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Xml;

namespace Sigedap.Helpers
{
    public static class ConfiguracionData
    {
        //todo: Son varias las oficinas comerciales por ueb
        public static string Ueb { set; get; }

        public static string OficinaComercial { set; get; }

        public static string Codigo { set; get; }

        public static void CargarConfiguracion(string path)
        {
            var reader = XmlReader.Create(path);
            while (reader.Read())
            {
                if (reader.MoveToContent() == XmlNodeType.Element && reader.Name == "ueb")
                {
                    ConfiguracionData.Ueb = reader.ReadElementContentAsString();
                }
                if (reader.MoveToContent() == XmlNodeType.Element && reader.Name == "oficinaComercial")
                {
                    ConfiguracionData.OficinaComercial = reader.ReadElementContentAsString();
                }
                if (reader.MoveToContent() == XmlNodeType.Element && reader.Name == "codigo")
                {
                    ConfiguracionData.Codigo = reader.ReadElementContentAsString();
                }
            }
            reader.Close();
        }
    }
}
