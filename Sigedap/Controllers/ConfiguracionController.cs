using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Sigedap.Helpers;
using Sigedap.ViewModels;

namespace Sigedap.Controllers
{
    public class ConfiguracionController : Controller
    {
        //
        // GET: /Configuracion/
        public ActionResult Index()
        {
            return View(new ConfiguracionViewModel { OficinaComercial = ConfiguracionData.OficinaComercial, Ueb = ConfiguracionData.Ueb, Codigo = ConfiguracionData.Codigo});
        }

        [HttpPost]
        public ActionResult Guardar(ConfiguracionViewModel config)
        {
            if (ModelState.IsValid)
            {
                GuardarConfiguracion(config.Ueb,config.OficinaComercial,config.Codigo);
                return RedirectToAction("Index", "Home");
            }
            return View("Index",config);
        }

        private void GuardarConfiguracion(string ueb, string oficinaComercial, string codigo)
        {
            ConfiguracionData.Ueb = ueb;
            ConfiguracionData.OficinaComercial = oficinaComercial;
            ConfiguracionData.Codigo = codigo;
            var path = Server.MapPath("~/ConfiguracionLocal.xml");
            var doc = new XmlDocument();
            doc.Load(path);
            var uebXml = doc.GetElementsByTagName("ueb")[0];
            uebXml.InnerText = ueb;

            var codXml = doc.GetElementsByTagName("codigo")[0];
            codXml.InnerText = codigo;
            
            var oficComXml = doc.GetElementsByTagName("oficinaComercial")[0];
            oficComXml.InnerText = oficinaComercial;

            doc.Save(path);
        }
    }
}