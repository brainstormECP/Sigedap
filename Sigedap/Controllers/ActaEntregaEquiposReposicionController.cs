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
    public class ActaEntregaEquiposReposicionController : Controller
    {
        private SigedapContext db = new SigedapContext();

        // GET: /ActaEntregaEquiposReposicion/
        public ActionResult Index(int id)
        {
            ViewBag.ExpedienteId = id;
            return View(db.ActasEntregaEquiposReposicion.Where(a =>a.ExpedienteDictamenDeReclamacionId == id).ToList());
        }

        // GET: /ActaEntregaEquiposReposicion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActaEntregaEquiposReposicion actaentregaequiposreposicion = db.ActasEntregaEquiposReposicion.Find(id);
            if (actaentregaequiposreposicion == null)
            {
                return HttpNotFound();
            }
            return View(actaentregaequiposreposicion);
        }

        // GET: /ActaEntregaEquiposReposicion/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var expediente = db.Expedientes.Find(id);
            if (expediente == null)
            {
                return HttpNotFound();
            }
            return View(new ActaEntregaEquiposReposicion(){ExpedienteDictamenDeReclamacionId = id.Value, Fecha = DateTime.Now});
        }

        // POST: /ActaEntregaEquiposReposicion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,ExpedienteDictamenDeReclamacionId,EquiposDañados")] ActaEntregaEquiposReposicion actaentregaequiposreposicion)
        {
            if (ModelState.IsValid)
            {
                actaentregaequiposreposicion.UsuarioId = User.Identity.GetUserId();
                db.ActasEntregaEquiposReposicion.Add(actaentregaequiposreposicion);
                db.SaveChanges();
                return RedirectToAction("Index", new{ id = actaentregaequiposreposicion.ExpedienteDictamenDeReclamacionId});
            }

            return View(actaentregaequiposreposicion);
        }

        // GET: /ActaEntregaEquiposReposicion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActaEntregaEquiposReposicion actaentregaequiposreposicion = db.ActasEntregaEquiposReposicion.Find(id);
            if (actaentregaequiposreposicion == null)
            {
                return HttpNotFound();
            }
            return View(actaentregaequiposreposicion);
        }

        // POST: /ActaEntregaEquiposReposicion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,ExpedienteDictamenDeReclamacionId,EquiposDañados")] ActaEntregaEquiposReposicion actaentregaequiposreposicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actaentregaequiposreposicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new{ id = actaentregaequiposreposicion.ExpedienteDictamenDeReclamacionId});
            }
            return View(actaentregaequiposreposicion);
        }

        // GET: /ActaEntregaEquiposReposicion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActaEntregaEquiposReposicion actaentregaequiposreposicion = db.ActasEntregaEquiposReposicion.Find(id);
            if (actaentregaequiposreposicion == null)
            {
                return HttpNotFound();
            }
            return View(actaentregaequiposreposicion);
        }

        // POST: /ActaEntregaEquiposReposicion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActaEntregaEquiposReposicion actaentregaequiposreposicion = db.ActasEntregaEquiposReposicion.Find(id);
            var expId = actaentregaequiposreposicion.ExpedienteDictamenDeReclamacionId;
            db.ActasEntregaEquiposReposicion.Remove(actaentregaequiposreposicion);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = expId });
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
