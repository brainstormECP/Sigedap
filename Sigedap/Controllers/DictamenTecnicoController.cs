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
    public class DictamenTecnicoController : Controller
    {
        private SigedapContext db = new SigedapContext();

        // GET: /DictamenTecnico/
        public ActionResult Index()
        {
            var dictamenestecnicos = db.DictamenesTecnicos.Include(d => d.EquipoDañado);
            return View(dictamenestecnicos.ToList());
        }

        // GET: /DictamenTecnico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictamenTecnico dictamentecnico = db.DictamenesTecnicos.Find(id);
            if (dictamentecnico == null)
            {
                return HttpNotFound();
            }
            return View(dictamentecnico);
        }

        // GET: /DictamenTecnico/Create
        public ActionResult Create()
        {
            ViewBag.EquipoDañadoId = new SelectList(db.EquiposDañados, "Id", "Nacionalidad");
            return View();
        }

        // POST: /DictamenTecnico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EquipoDañadoId,Numero,Fecha,Tecnico1,Tecnico2,Tecnico3,RecibidoPor,Destino")] DictamenTecnico dictamentecnico)
        {
            if (ModelState.IsValid)
            {
                db.DictamenesTecnicos.Add(dictamentecnico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipoDañadoId = new SelectList(db.EquiposDañados, "Id", "Nacionalidad", dictamentecnico.EquipoDañadoId);
            return View(dictamentecnico);
        }

        // GET: /DictamenTecnico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictamenTecnico dictamentecnico = db.DictamenesTecnicos.Find(id);
            if (dictamentecnico == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipoDañadoId = new SelectList(db.EquiposDañados, "Id", "Nacionalidad", dictamentecnico.EquipoDañadoId);
            return View(dictamentecnico);
        }

        // POST: /DictamenTecnico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EquipoDañadoId,Numero,Fecha,Tecnico1,Tecnico2,Tecnico3,RecibidoPor,Destino")] DictamenTecnico dictamentecnico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dictamentecnico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipoDañadoId = new SelectList(db.EquiposDañados, "Id", "Nacionalidad", dictamentecnico.EquipoDañadoId);
            return View(dictamentecnico);
        }

        // GET: /DictamenTecnico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DictamenTecnico dictamentecnico = db.DictamenesTecnicos.Find(id);
            if (dictamentecnico == null)
            {
                return HttpNotFound();
            }
            return View(dictamentecnico);
        }

        // POST: /DictamenTecnico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DictamenTecnico dictamentecnico = db.DictamenesTecnicos.Find(id);
            db.DictamenesTecnicos.Remove(dictamentecnico);
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
