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
    public class DictamenPorPartesController : Controller
    {
        private SigedapContext db = new SigedapContext();

        // GET: /DictamenPorPartes/
        public ActionResult Index()
        {
            var dictamenesporpartes = db.DictamenesPorPartes.Include(d => d.DictamenTecnico);
            return View(dictamenesporpartes.ToList());
        }

        // GET: /DictamenPorPartes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictamenPorPartes dictamenporpartes = db.DictamenesPorPartes.Find(id);
            if (dictamenporpartes == null)
            {
                return HttpNotFound();
            }
            return View(dictamenporpartes);
        }

        // GET: /DictamenPorPartes/Create
        public ActionResult Create()
        {
            ViewBag.DictamenTecnicoEquipoDañadoId = new SelectList(db.DictamenesTecnicos, "EquipoDañadoId", "Tecnico1");
            return View();
        }

        // POST: /DictamenPorPartes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Descripcion,Defecto,DictamenTecnicoEquipoDañadoId")] DictamenPorPartes dictamenporpartes)
        {
            if (ModelState.IsValid)
            {
                db.DictamenesPorPartes.Add(dictamenporpartes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DictamenTecnicoEquipoDañadoId = new SelectList(db.DictamenesTecnicos, "EquipoDañadoId", "Tecnico1", dictamenporpartes.DictamenTecnicoEquipoDañadoId);
            return View(dictamenporpartes);
        }

        // GET: /DictamenPorPartes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictamenPorPartes dictamenporpartes = db.DictamenesPorPartes.Find(id);
            if (dictamenporpartes == null)
            {
                return HttpNotFound();
            }
            ViewBag.DictamenTecnicoEquipoDañadoId = new SelectList(db.DictamenesTecnicos, "EquipoDañadoId", "Tecnico1", dictamenporpartes.DictamenTecnicoEquipoDañadoId);
            return View(dictamenporpartes);
        }

        // POST: /DictamenPorPartes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Descripcion,Defecto,DictamenTecnicoEquipoDañadoId")] DictamenPorPartes dictamenporpartes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dictamenporpartes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DictamenTecnicoEquipoDañadoId = new SelectList(db.DictamenesTecnicos, "EquipoDañadoId", "Tecnico1", dictamenporpartes.DictamenTecnicoEquipoDañadoId);
            return View(dictamenporpartes);
        }

        // GET: /DictamenPorPartes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictamenPorPartes dictamenporpartes = db.DictamenesPorPartes.Find(id);
            if (dictamenporpartes == null)
            {
                return HttpNotFound();
            }
            return View(dictamenporpartes);
        }

        // POST: /DictamenPorPartes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DictamenPorPartes dictamenporpartes = db.DictamenesPorPartes.Find(id);
            db.DictamenesPorPartes.Remove(dictamenporpartes);
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
