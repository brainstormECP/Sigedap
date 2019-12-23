using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.ASPxHtmlEditor.Internal;
using Microsoft.AspNet.Identity;
using Sigedap.Helpers;
using Sigedap.Models;

namespace Sigedap.Controllers
{
    public class ExpedienteController : Controller
    {
        private SigedapContext db = new SigedapContext();

        // GET: /Expediente/
        public ActionResult Index()
        {
            var expedientes = db.Expedientes.Include(e => e.Despachador).Include(e => e.DictamenDeReclamacion).Include(e => e.Inspector).Include(e => e.Operario);
            return View(expedientes.ToList());
        }

        // GET: /Expediente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expediente expediente = db.Expedientes.Find(id);
            if (expediente == null)
            {
                return HttpNotFound();
            }
            return View(expediente);
        }

        // GET: /Expediente/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dictamenReclamacion = db.DictamenesDeReclamacion.Find(id);
            //todo: revisar el consecutivo del expediente
            var count = db.Expedientes.Count() + 1;
            var año = DateTime.Now.Year.ToString().Substring(2, 2);
            if (!db.Expedientes.Any(e =>e.DictamenDeReclamacionId == id))
            {
                var expediente = new Expediente()
                {
                    Numero = ConfiguracionData.Codigo + "-" + count + "-" + año,
                    DictamenDeReclamacion = dictamenReclamacion,
                    DictamenDeReclamacionId = dictamenReclamacion.Id,
                    FechaAfectacion = DateTime.Now,
                    FechaDeNormalizacionServicio = DateTime.Now,
                    FechaNt = DateTime.Now,
                    FechaRecibidoUebMunicipal = DateTime.Now,
                    FechaVisitaCliente = DateTime.Now,
                    PagadoHasta = DateTime.Now
                    
                };
                ViewBag.DespachadorId = new SelectList(db.Despachadores, "Id", "NombreCompleto");
                ViewBag.InspectorId = new SelectList(db.Inspectores, "Id", "NombreCompleto");
                ViewBag.OperarioId = new SelectList(db.Operarios, "Id", "NombreCompleto");
                return View(expediente);
            }
            return RedirectToAction("Details",new{id=id});
        }

        // POST: /Expediente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DictamenDeReclamacionId,Numero,Causas,AmparadoPorNt,FechaAfectacion,FechaDeNormalizacionServicio,FechaRecibidoUebMunicipal,FechaVisitaCliente,FechaNt,Observaciones,OperarioId,InspectorId,DespachadorId,PagadoHasta")] Expediente expediente)
        {
            var año = DateTime.Now.Year.ToString().Substring(2, 2);
            var count = db.Expedientes.Count();
            expediente.Numero = ConfiguracionData.Codigo + "-" + count + "-" + año;
            if (ModelState.IsValid)
            {
                db.Expedientes.Add(expediente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DespachadorId = new SelectList(db.Despachadores, "Id", "NombreCompleto", expediente.DespachadorId);
            ViewBag.InspectorId = new SelectList(db.Inspectores, "Id", "NombreCompleto", expediente.InspectorId);
            ViewBag.OperarioId = new SelectList(db.Operarios, "Id", "NombreCompleto", expediente.OperarioId);
            return View(expediente);
        }

        public ActionResult ActaRecogidaTaller(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!db.ActasRecogidaEquipos.Any(e => e.ExpedienteDictamenDeReclamacionId == id))
            {
                return View(new ActaRecogidaEquipos() { ExpedienteDictamenDeReclamacionId = id.Value, Fecha = DateTime.Now });
            }
            var acta = db.ActasRecogidaEquipos.Single(e => e.ExpedienteDictamenDeReclamacionId == id);
            return View(acta);
        }

        [HttpPost]
        public ActionResult ActaRecogidaTaller(ActaRecogidaEquipos acta)
        {
            if (ModelState.IsValid)
            {
                if (db.ActasRecogidaEquipos.Any(d => d.ExpedienteDictamenDeReclamacionId == acta.ExpedienteDictamenDeReclamacionId))
                {
                    db.ActasRecogidaEquipos.Attach(acta);
                    var entry = db.Entry(acta);
                    entry.State = EntityState.Modified;
                }
                else
                {
                    db.ActasRecogidaEquipos.Add(acta);
                }
                db.SaveChanges();
                return RedirectToAction("Details", new { id = acta.ExpedienteDictamenDeReclamacionId });
            }
            return View(acta);
        }


        public ActionResult EquiposDañados(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expediente expediente = db.Expedientes.Single(e => e.DictamenDeReclamacionId == id);
            db.Entry(expediente).Collection(e => e.EquiposDañados).Load();
            if (expediente == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpedienteId = id;
            return View(expediente.EquiposDañados);
        }

        public ActionResult Dictamen(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var equipo = db.EquiposDañados.Include(e => e.DictamenTecnico).Single(e => e.Id == id);
            if (equipo  == null)
            {
                return HttpNotFound();
            }
            if (equipo.DictamenTecnico == null)
            {
                ViewBag.ExpedienteId = equipo.ExpedienteDictamenDeReclamacionId;
                return View(new DictamenTecnico(){EquipoDañadoId = equipo.Id, Fecha = DateTime.Now});
            }
            ViewBag.ExpedienteId = equipo.ExpedienteDictamenDeReclamacionId;
            return View(equipo.DictamenTecnico);
        }

        [HttpPost]
        public ActionResult Dictamen(DictamenTecnico dictamen)
        {
            if (ModelState.IsValid)
            {
                if (db.DictamenesTecnicos.Any(d => d.EquipoDañadoId == dictamen.EquipoDañadoId))
                {
                    db.DictamenesTecnicos.Attach(dictamen);
                    var entry = db.Entry(dictamen);
                    entry.Reference(d => d.EquipoDañado).Load();
                    entry.State = EntityState.Modified;
                }
                else
                {
                    db.DictamenesTecnicos.Add(dictamen);
                }
                db.SaveChanges();
                var dic = db.Entry(dictamen);
                dic.Reference(d => d.EquipoDañado).Load();
                return RedirectToAction("EquiposDañados",new{id = dictamen.EquipoDañado.ExpedienteDictamenDeReclamacionId});
            }
            var equipo = db.EquiposDañados.Find(dictamen.EquipoDañadoId);
            ViewBag.ExpedienteId = equipo.ExpedienteDictamenDeReclamacionId;
            return View(dictamen);
        }

        public ActionResult ActaDevolucionEquipo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!db.ActasDevoluciones.Any(e => e.ExpedienteDictamenDeReclamacionId == id))
            {
                return View(new ActaDevolucion() { ExpedienteDictamenDeReclamacionId = id.Value, Fecha = DateTime.Now });
            }
            var acta = db.ActasDevoluciones.Single(e => e.ExpedienteDictamenDeReclamacionId == id);
            return View(acta);
        }

        [HttpPost]
        public ActionResult ActaDevolucionEquipo(ActaDevolucion acta)
        {
            if (ModelState.IsValid)
            {
                if (db.ActasDevoluciones.Any(d => d.ExpedienteDictamenDeReclamacionId == acta.ExpedienteDictamenDeReclamacionId))
                {
                    db.ActasDevoluciones.Attach(acta);
                    var entry = db.Entry(acta);
                    entry.State = EntityState.Modified;
                }
                else
                {
                    db.ActasDevoluciones.Add(acta);
                }
                db.SaveChanges();
                return RedirectToAction("Details", new { id = acta.ExpedienteDictamenDeReclamacionId });
            }
            return View(acta);
        }

        public ActionResult SolicitudReposicion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!db.SolicitudesReposicion.Any(e => e.ExpedienteDictamenDeReclamacionId == id))
            {
                return View(new SolicitudReposicion() { ExpedienteDictamenDeReclamacionId = id.Value, Fecha = DateTime.Now });
            }
            var acta = db.SolicitudesReposicion.Single(e => e.ExpedienteDictamenDeReclamacionId == id);
            return View(acta);
        }

        [HttpPost]
        public ActionResult SolicitudReposicion(SolicitudReposicion solicitud)
        {
            if (ModelState.IsValid)
            {
                if (db.SolicitudesReposicion.Any(d => d.ExpedienteDictamenDeReclamacionId == solicitud.ExpedienteDictamenDeReclamacionId))
                {
                    db.SolicitudesReposicion.Attach(solicitud);
                    var entry = db.Entry(solicitud);
                    entry.State = EntityState.Modified;
                }
                else
                {
                    db.SolicitudesReposicion.Add(solicitud);
                }
                db.SaveChanges();
                return RedirectToAction("Details", new { id = solicitud.ExpedienteDictamenDeReclamacionId });
            }
            return View(solicitud);
        }

        // GET: /Expediente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expediente expediente = db.Expedientes.Single(e => e.DictamenDeReclamacionId == id);
            db.Entry(expediente).Collection(e => e.EquiposDañados).Load();
            if (expediente == null)
            {
                return HttpNotFound();
            }
            ViewBag.DespachadorId = new SelectList(db.Despachadores, "Id", "NombreCompleto", expediente.DespachadorId);
            ViewBag.InspectorId = new SelectList(db.Inspectores, "Id", "NombreCompleto", expediente.InspectorId);
            ViewBag.OperarioId = new SelectList(db.Operarios, "Id", "NombreCompleto", expediente.OperarioId);
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre");
            ViewBag.TipoDeEquipoId = new SelectList(db.TiposDeEquipos, "Id", "Nombre");
            return View(expediente);
        }

        // POST: /Expediente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DictamenDeReclamacionId,Numero,Causas,AmparadoPorNt,FechaAfectacion,FechaDeNormalizacionServicio,FechaRecibidoUebMunicipal,FechaVisitaCliente,FechaNt,Observaciones,OperarioId,InspectorId,DespachadorId,PagadoHasta")] Expediente expediente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expediente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DespachadorId = new SelectList(db.Despachadores, "Id", "NombreCompleto", expediente.DespachadorId);
            ViewBag.InspectorId = new SelectList(db.Inspectores, "Id", "NombreCompleto", expediente.InspectorId);
            ViewBag.OperarioId = new SelectList(db.Operarios, "Id", "NombreCompleto", expediente.OperarioId);
            return View(expediente);
        }

        // GET: /Expediente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expediente expediente = db.Expedientes.Find(id);
            if (expediente == null)
            {
                return HttpNotFound();
            }
            return View(expediente);
        }

        // POST: /Expediente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expediente expediente = db.Expedientes.Find(id);
            db.Expedientes.Remove(expediente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult EquipoDañadoForm(int? id)
        {
            if (id == null)
            {
                return PartialView("_EquipoDañadoPartial");
            }
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre");
            ViewBag.TipoDeEquipoId = new SelectList(db.TiposDeEquipos, "Id", "Nombre");
            ViewBag.ExpedienteId = id;
            return PartialView("_EquipoDañadoPartial", new EquipoDañado(){ExpedienteDictamenDeReclamacionId = id.Value});
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
