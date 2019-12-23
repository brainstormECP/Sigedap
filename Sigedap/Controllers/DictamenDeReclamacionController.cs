using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Sigedap.Models;


namespace Sigedap.Controllers
{
    public class DictamenDeReclamacionController : Controller
    {
        private SigedapContext db = new SigedapContext();

        // GET: /DictamenDeReclamacion/
        public ActionResult Index()
        {
            var dictamenesdereclamacion = db.DictamenesDeReclamacion.Include(d => d.Cliente);
            return View(dictamenesdereclamacion.ToList());
        }

        // GET: /DictamenDeReclamacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictamenDeReclamacion dictamendereclamacion = db.DictamenesDeReclamacion.Find(id);
            if (dictamendereclamacion == null)
            {
                return HttpNotFound();
            }
            return View(dictamendereclamacion);
        }

        // GET: /DictamenDeReclamacion/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Ci");
            return View();
        }

        // POST: /DictamenDeReclamacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Ueb,OficinaComercial,Procede,Observaciones,RevisadoPor,AutorizadoPor,FechaNotificacionAlCliente,NombreReclamante,CiReclamante,ClienteId")] DictamenDeReclamacion dictamendereclamacion)
        {
            dictamendereclamacion.UsuarioId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.DictamenesDeReclamacion.Add(dictamendereclamacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Ci", dictamendereclamacion.ClienteId);
            return View(dictamendereclamacion);
        }

        // GET: /DictamenDeReclamacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictamenDeReclamacion dictamendereclamacion = db.DictamenesDeReclamacion.Find(id);
            if (dictamendereclamacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Ci", dictamendereclamacion.ClienteId);
            return View(dictamendereclamacion);
        }

        // POST: /DictamenDeReclamacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Ueb,OficinaComercial,Procede,Observaciones,RevisadoPor,AutorizadoPor,FechaNotificacionAlCliente,NombreReclamante,CiReclamante,ClienteId")] DictamenDeReclamacion dictamendereclamacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dictamendereclamacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Ci", dictamendereclamacion.ClienteId);
            return View(dictamendereclamacion);
        }

        // GET: /DictamenDeReclamacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictamenDeReclamacion dictamendereclamacion = db.DictamenesDeReclamacion.Find(id);
            if (dictamendereclamacion == null)
            {
                return HttpNotFound();
            }
            return View(dictamendereclamacion);
        }

        // POST: /DictamenDeReclamacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DictamenDeReclamacion dictamendereclamacion = db.DictamenesDeReclamacion.Find(id);
            db.DictamenesDeReclamacion.Remove(dictamendereclamacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
