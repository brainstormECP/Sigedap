using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sigedap.Reportes;
using DevExpress.XtraReports.UI;
using DevExpress.Web.Mvc;

namespace Sigedap.Controllers
{
    public class ReportesController : Controller
    {
        static Dictionary<string, XtraReport> reports = new Dictionary<string, XtraReport>();

        public ActionResult ReportViewerPartial(string reporteId){
            return PartialView("ReportViewerPartial",reports[reporteId]);
        }
        public ActionResult ExportReportViewer(string reporteId)
        {
            var reporte = reports[reporteId];
            reports.Remove(reporteId);
            return DevExpress.Web.Mvc.ReportViewerExtension.ExportTo(reporte);
        }

        //
        // GET: /Reportes/
        public ActionResult Expediente(int id)
        {
            var report = new Expediente_de_Reclamacion(id);
            string random = System.IO.Path.GetRandomFileName().Replace(".", string.Empty);
            reports.Add(random,report);
            ViewData["ReporteId"] = random;
            return View("Plantilla");
        }
        
        //todo: Permitir que de la vista de imprimir regrese a la vista de donde sale
        public ActionResult ActaRecogidaEquipos(int id)
        {
            var report = new Acta_Recogida_Traslado(id);
            string random = System.IO.Path.GetRandomFileName().Replace(".", string.Empty);
            reports.Add(random,report);
            ViewData["ReporteId"] = random;
            return View("Plantilla");
        }

        public ActionResult DictamenDeReclamacion(){
            var report = new Dictamen_de_Reclamacion();
            string random = System.IO.Path.GetRandomFileName().Replace(".", string.Empty);
            reports.Add(random, report);
            ViewData["ReporteId"] = random;
            return View("Plantilla");
        }

        public ActionResult DictamenTecnico(int id)
        {
            var report = new Dictamen_de_Reclamacion();
            string random = System.IO.Path.GetRandomFileName().Replace(".", string.Empty);
            reports.Add(random, report);
            ViewData["ReporteId"] = random;
            return View("Plantilla");
        }

        public ActionResult ActaDevolucionEquipos(int id)
        {
            var report = new Acta_de_Devolucion_Baja(id);
            string random = System.IO.Path.GetRandomFileName().Replace(".", string.Empty);
            reports.Add(random, report);
            ViewData["ReporteId"] = random;
            return View("Plantilla");
        }
        public ActionResult SolicitudReposicion(int id)
        {
            var report = new Solicitud_de_Reposicion(id);
            string random = System.IO.Path.GetRandomFileName().Replace(".", string.Empty);
            reports.Add(random, report);
            ViewData["ReporteId"] = random;
            return View("Plantilla");
        }
        
	}
}