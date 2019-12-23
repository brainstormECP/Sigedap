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
    public class ActaDevolucionController : Controller
    {
        private SigedapContext db = new SigedapContext();

        // GET: /ActaDevolucion/
        public ActionResult Index()
        {
            return View(db.ActasDevoluciones.ToList());
        }

        // GET: /ActaDevolucion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActaDevolucion actadevolucion = db.ActasDevoluciones.Find(id);
            if (actadevolucion == null)
            {
                return HttpNotFound();
            }
            return View(actadevolucion);
        }

        // GET: /ActaDevolucion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ActaDevolucion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Fecha,Representante,CiRepresentante,ExpedienteId")] ActaDevolucion actadevolucion)
        {
            if (ModelState.IsValid)
            {
                db.ActasDevoluciones.Add(actadevolucion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actadevolucion);
        }

        // GET: /ActaDevolucion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActaDevolucion actadevolucion = db.ActasDevoluciones.Find(id);
            if (actadevolucion == null)
            {
                return HttpNotFound();
            }
            return View(actadevolucion);
        }

        // POST: /ActaDevolucion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Fecha,Representante,CiRepresentante,ExpedienteId")] ActaDevolucion actadevolucion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actadevolucion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actadevolucion);
        }

        // GET: /ActaDevolucion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActaDevolucion actadevolucion = db.ActasDevoluciones.Find(id);
            if (actadevolucion == null)
            {
                return HttpNotFound();
            }
            return View(actadevolucion);
        }

        // POST: /ActaDevolucion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActaDevolucion actadevolucion = db.ActasDevoluciones.Find(id);
            db.ActasDevoluciones.Remove(actadevolucion);
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
