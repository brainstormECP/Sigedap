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
    public class SolicitudReposicionController : Controller
    {
        private SigedapContext db = new SigedapContext();

        // GET: /SolicitudReposicion/
        public ActionResult Index()
        {
            return View(db.SolicitudesReposicion.ToList());
        }

        // GET: /SolicitudReposicion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudReposicion SolicitudReposicion = db.SolicitudesReposicion.Find(id);
            if (SolicitudReposicion == null)
            {
                return HttpNotFound();
            }
            return View(SolicitudReposicion);
        }

        // GET: /SolicitudReposicion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SolicitudReposicion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Fecha,Especialista")] SolicitudReposicion SolicitudReposicion)
        {
            if (ModelState.IsValid)
            {
                db.SolicitudesReposicion.Add(SolicitudReposicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(SolicitudReposicion);
        }

        // GET: /SolicitudReposicion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudReposicion SolicitudReposicion = db.SolicitudesReposicion.Find(id);
            if (SolicitudReposicion == null)
            {
                return HttpNotFound();
            }
            return View(SolicitudReposicion);
        }

        // POST: /SolicitudReposicion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Fecha,Especialista")] SolicitudReposicion SolicitudReposicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(SolicitudReposicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(SolicitudReposicion);
        }

        // GET: /SolicitudReposicion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SolicitudReposicion SolicitudReposicion = db.SolicitudesReposicion.Find(id);
            if (SolicitudReposicion == null)
            {
                return HttpNotFound();
            }
            return View(SolicitudReposicion);
        }

        // POST: /SolicitudReposicion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SolicitudReposicion SolicitudReposicion = db.SolicitudesReposicion.Find(id);
            db.SolicitudesReposicion.Remove(SolicitudReposicion);
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
