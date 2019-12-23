using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sigedap.Helpers;

namespace Sigedap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ConfiguracionData.CargarConfiguracion(Server.MapPath("ConfiguracionLocal.xml"));
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}