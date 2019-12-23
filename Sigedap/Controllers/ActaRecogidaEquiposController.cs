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
    public class ActaRecogidaEquiposController : Controller
    {
        private SigedapContext db = new SigedapContext();

        // GET: /ActaRecogidaEquipos/
        public ActionResult Index()
        {
            return View(db.ActasRecogidaEquipos.ToList());
        }

        // GET: /ActaRecogidaEquipos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActaRecogidaEquipos actarecogidaequipos = db.ActasRecogidaEquipos.Find(id);
            if (actarecogidaequipos == null)
            {
                return HttpNotFound();
            }
            return View(actarecogidaequipos);
        }

        // GET: /ActaRecogidaEquipos/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dictamenReclamacion = db.DictamenesDeReclamacion.Find(id);
            if (db.ActasRecogidaEquipos.Any(a => a.ExpedienteDictamenDeReclamacionId == id))
            {
                return RedirectToAction("Details", new { id = id });
            }
            var acta = new ActaRecogidaEquipos()
            {
                Expediente = dictamenReclamacion.Expediente,
                ExpedienteDictamenDeReclamacionId = dictamenReclamacion.Id,
                Fecha = DateTime.Now
            };
            return View(acta);
        }

        // POST: /ActaRecogidaEquipos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,NombreRepresentante,CiRepresentante,ExpedienteId,ExpedienteDictamenDeReclamacionId")] ActaRecogidaEquipos actarecogidaequipos)
        {
            if (ModelState.IsValid)
            {
                db.ActasRecogidaEquipos.Add(actarecogidaequipos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actarecogidaequipos);
        }

        // GET: /ActaRecogidaEquipos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActaRecogidaEquipos actarecogidaequipos = db.ActasRecogidaEquipos.Find(id);
            if (actarecogidaequipos == null)
            {
                return HttpNotFound();
            }
            return View(actarecogidaequipos);
        }

        // POST: /ActaRecogidaEquipos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Fecha,NombreRepresentante,CiRepresentante,ExpedienteId")] ActaRecogidaEquipos actarecogidaequipos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actarecogidaequipos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actarecogidaequipos);
        }

        // GET: /ActaRecogidaEquipos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActaRecogidaEquipos actarecogidaequipos = db.ActasRecogidaEquipos.Find(id);
            if (actarecogidaequipos == null)
            {
                return HttpNotFound();
            }
            return View(actarecogidaequipos);
        }

        // POST: /ActaRecogidaEquipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActaRecogidaEquipos actarecogidaequipos = db.ActasRecogidaEquipos.Find(id);
            db.ActasRecogidaEquipos.Remove(actarecogidaequipos);
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
