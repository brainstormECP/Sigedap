using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sigedap.Helpers;
using Sigedap.Models;
using Sigedap.ViewModels;

namespace Sigedap.Controllers
{
    public class ReclamacionController : Controller
    {
        private SigedapContext db = new SigedapContext();
        //
        // GET: /Reclamacion/
        public ActionResult Index()
        {
            return View(db.DictamenesDeReclamacion.ToList());
        }

        // GET: /Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cliente,DictamenDeReclamacion")] ReclamacionViewModel reclamacion)
        {
            if (ModelState.IsValid)
            {
                reclamacion.DictamenDeReclamacion.Ueb = ConfiguracionData.Ueb;
                reclamacion.DictamenDeReclamacion.OficinaComercial = ConfiguracionData.OficinaComercial;
                db.Clientes.Add(reclamacion.Cliente);
                reclamacion.DictamenDeReclamacion.FechaNotificacionAlCliente = DateTime.Now;
                db.DictamenesDeReclamacion.Add(reclamacion.DictamenDeReclamacion);
                db.SaveChanges();
                TempData["success"] = "Se agrego correctamente una nueva reclamacion";
                return RedirectToAction("Index");
            }
            return View(reclamacion);
        }
	}
}