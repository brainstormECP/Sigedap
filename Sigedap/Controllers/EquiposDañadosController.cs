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
    public class EquiposDañadosController : Controller
    {
        private SigedapContext db = new SigedapContext();

        // GET: /EquiposDañados/
        public ActionResult Index()
        {
            var equiposdañados = db.EquiposDañados.Include(e => e.ActaEntregaEquiposReposicion).Include(e => e.ActasRecogidaDestruir).Include(e => e.Marca);
            return View(equiposdañados.ToList());
        }

        // GET: /EquiposDañados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoDañado equipodañado = db.EquiposDañados.Find(id);
            if (equipodañado == null)
            {
                return HttpNotFound();
            }
            return View(equipodañado);
        }

        // GET: /EquiposDañados/Create
        public ActionResult Create()
        {
            ViewBag.TipoDeEquipoId = new SelectList(db.TiposDeEquipos, "Id", "Nombre");
            ViewBag.ExpedienteDictamenDeReclamacionId = new SelectList(db.Expedientes, "DictamenDeReclamacionId", "Numero");
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre");
            return View();
        }

        // POST: /EquiposDañados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nacionalidad,Serie,Modelo,Descripcion,ExpedienteDictamenDeReclamacionId,MarcaId,TipoDeEquipoId")] EquipoDañado equipodañado)
        {
            if (ModelState.IsValid)
            {
                db.EquiposDañados.Add(equipodañado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoDeEquipoId = new SelectList(db.TiposDeEquipos, "Id", "Nombre", equipodañado.TipoDeEquipoId);
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre", equipodañado.MarcaId);
            ViewBag.ExpedienteDictamenDeReclamacionId = new SelectList(db.Expedientes, "DictamenDeReclamacionId", "Numero", equipodañado.ExpedienteDictamenDeReclamacionId);
            return View(equipodañado);
        }

        // GET: /EquiposDañados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoDañado equipodañado = db.EquiposDañados.Find(id);
            if (equipodañado == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDeEquipoId = new SelectList(db.TiposDeEquipos, "Id", "Nombre", equipodañado.TipoDeEquipoId);
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre", equipodañado.MarcaId);
            ViewBag.ExpedienteDictamenDeReclamacionId = new SelectList(db.Expedientes, "DictamenDeReclamacionId", "Numero", equipodañado.ExpedienteDictamenDeReclamacionId);
            return View(equipodañado);
        }

        // POST: /EquiposDañados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nacionalidad,Serie,Modelo,Descripcion,ExpedienteDictamenDeReclamacionId,MarcaId,TipoDeEquipoId")] EquipoDañado equipodañado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipodañado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoDeEquipoId = new SelectList(db.TiposDeEquipos, "Id", "Nombre", equipodañado.TipoDeEquipoId);
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre", equipodañado.MarcaId);
            ViewBag.ExpedienteDictamenDeReclamacionId = new SelectList(db.Expedientes, "DictamenDeReclamacionId", "Numero", equipodañado.ExpedienteDictamenDeReclamacionId);
            return View(equipodañado);
        }

        // GET: /EquiposDañados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoDañado equipodañado = db.EquiposDañados.Find(id);
            if (equipodañado == null)
            {
                return HttpNotFound();
            }
            return View(equipodañado);
        }

        // POST: /EquiposDañados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoDañado equipodañado = db.EquiposDañados.Find(id);
            db.EquiposDañados.Remove(equipodañado);
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
