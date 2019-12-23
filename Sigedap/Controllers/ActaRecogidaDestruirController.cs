using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sigedap.Models;


namespace Sigedap.Controllers
{
    public class ActaRecogidaDestruirController : Controller
    {
        private SigedapContext db = new SigedapContext();

        // GET: /ActaRecogidaDestruir/
        public ActionResult Index(int id)
        {
            ViewBag.ExpedienteId = id;
            return View(db.ActasRecogidaDestruir.Where(a =>a.ExpedienteDictamenDeReclamacionId == id).ToList());
        }

        // GET: /ActaRecogidaDestruir/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(new ActaRecogidaDestruir(){ExpedienteDictamenDeReclamacionId = id.Value, Fecha = DateTime.Now, FechaDestruccion = DateTime.Now, FechaEntregaAlmacen = DateTime.Now});
        }

        // POST: /ActaRecogidaDestruir/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Testigo2,Testigo1,Testigo3,FechaDestruccion,FechaEntregaAlmacen,ExpedienteDictamenDeReclamacionId,RecibidoPor,ExpedienteDictamenDeReclamacionId")] ActaRecogidaDestruir actarecogidadestruir)
        {
            if (ModelState.IsValid)
            {
                db.ActasRecogidaDestruir.Add(actarecogidadestruir);
                db.SaveChanges();
                return RedirectToAction("Index",new{id = actarecogidadestruir.ExpedienteDictamenDeReclamacionId});
            }

            return View(actarecogidadestruir);
        }

        // GET: /ActaRecogidaDestruir/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActaRecogidaDestruir actarecogidadestruir = db.ActasRecogidaDestruir.Find(id);
            if (actarecogidadestruir == null)
            {
                return HttpNotFound();
            }
            return View(actarecogidadestruir);
        }

        // POST: /ActaRecogidaDestruir/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Testigo2,Testigo1,Testigo3,FechaDestruccion,FechaEntregaAlmacen,ExpedienteDictamenDeReclamacionId,RecibidoPor,ExpedienteDictamenDeReclamacionId")] ActaRecogidaDestruir actarecogidadestruir)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actarecogidadestruir).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index",new{id = actarecogidadestruir.ExpedienteDictamenDeReclamacionId});
            }
            return View(actarecogidadestruir);
        }

        // GET: /ActaRecogidaDestruir/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActaRecogidaDestruir actarecogidadestruir = db.ActasRecogidaDestruir.Find(id);
            if (actarecogidadestruir == null)
            {
                return HttpNotFound();
            }
            return View(actarecogidadestruir);
        }

        // POST: /ActaRecogidaDestruir/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActaRecogidaDestruir actarecogidadestruir = db.ActasRecogidaDestruir.Find(id);
            var expId = actarecogidadestruir.ExpedienteDictamenDeReclamacionId;
            db.ActasRecogidaDestruir.Remove(actarecogidadestruir);
            db.SaveChanges();
            return RedirectToAction("Index",new{id = expId});
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
