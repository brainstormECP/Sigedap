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
    public class TipoDeEquipoController : Controller
    {
        private SigedapContext db = new SigedapContext();

        // GET: /TipoDeEquipo/
        public ActionResult Index()
        {
            return View(db.TiposDeEquipos.ToList());
        }

        // GET: /TipoDeEquipo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeEquipo tipodeequipo = db.TiposDeEquipos.Find(id);
            if (tipodeequipo == null)
            {
                return HttpNotFound();
            }
            return View(tipodeequipo);
        }

        // GET: /TipoDeEquipo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoDeEquipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nombre")] TipoDeEquipo tipodeequipo)
        {
            if (ModelState.IsValid)
            {
                db.TiposDeEquipos.Add(tipodeequipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipodeequipo);
        }

        // GET: /TipoDeEquipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeEquipo tipodeequipo = db.TiposDeEquipos.Find(id);
            if (tipodeequipo == null)
            {
                return HttpNotFound();
            }
            return View(tipodeequipo);
        }

        // POST: /TipoDeEquipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nombre")] TipoDeEquipo tipodeequipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipodeequipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipodeequipo);
        }

        // GET: /TipoDeEquipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeEquipo tipodeequipo = db.TiposDeEquipos.Find(id);
            if (tipodeequipo == null)
            {
                return HttpNotFound();
            }
            return View(tipodeequipo);
        }

        // POST: /TipoDeEquipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeEquipo tipodeequipo = db.TiposDeEquipos.Find(id);
            db.TiposDeEquipos.Remove(tipodeequipo);
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
