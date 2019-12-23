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
    public class OperadorController : Controller
    {
        private SigedapContext db = new SigedapContext();

        // GET: /Operador/
        public ActionResult Index()
        {
            return View(db.Operarios.ToList());
        }

        // GET: /Operador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operario operario = db.Operarios.Find(id);
            if (operario == null)
            {
                return HttpNotFound();
            }
            return View(operario);
        }

        // GET: /Operador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Operador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nombres,Apellidos")] Operario operario)
        {
            operario.Activo = true;
            if (ModelState.IsValid)
            {
                db.Trabajadores.Add(operario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(operario);
        }

        // GET: /Operador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operario operario = db.Operarios.Find(id);
            if (operario == null)
            {
                return HttpNotFound();
            }
            return View(operario);
        }

        // POST: /Operador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nombres,Apellidos,Activo")] Operario operario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(operario);
        }

        // GET: /Operador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operario operario = db.Operarios.Find(id);
            if (operario == null)
            {
                return HttpNotFound();
            }
            return View(operario);
        }

        // POST: /Operador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operario operario = db.Operarios.Find(id);
            operario.Activo = false;
            db.Entry(operario).State = EntityState.Modified;
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
