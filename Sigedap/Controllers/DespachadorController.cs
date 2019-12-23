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
    public class DespachadorController : Controller
    {
        private SigedapContext db = new SigedapContext();

        // GET: /Despachador/
        public ActionResult Index()
        {
            return View(db.Despachadores.ToList());
        }

        // GET: /Despachador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despachador despachador = db.Despachadores.Find(id);
            if (despachador == null)
            {
                return HttpNotFound();
            }
            return View(despachador);
        }

        // GET: /Despachador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Despachador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nombres,Apellidos")] Despachador despachador)
        {
            despachador.Activo = true;
            if (ModelState.IsValid)
            {
                db.Trabajadores.Add(despachador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(despachador);
        }

        // GET: /Despachador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despachador despachador = db.Despachadores.Find(id);
            if (despachador == null)
            {
                return HttpNotFound();
            }
            return View(despachador);
        }

        // POST: /Despachador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nombres,Apellidos,Activo")] Despachador despachador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(despachador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(despachador);
        }

        // GET: /Despachador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despachador despachador = db.Despachadores.Find(id);
            if (despachador == null)
            {
                return HttpNotFound();
            }
            return View(despachador);
        }

        // POST: /Despachador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Despachador despachador = db.Despachadores.Find(id);
            despachador.Activo = false;
            db.Entry(despachador).State = EntityState.Modified;
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
