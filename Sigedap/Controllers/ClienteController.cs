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
    public class ClienteController : Controller
    {
        private SigedapContext db = new SigedapContext();

        // GET: /Cliente/
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: /Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: /Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Ci,Nombres,PrimerApellido,SegundoApellido,Calle,No,Piso,Apto,EntreCalle1,EntreCalle2,Rpto,Municipio,TelefonoParticular,TelefonoTrabajo,Control,Ruta,Folio")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: /Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: /Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Ci,Nombres,PrimerApellido,SegundoApellido,Calle,No,Piso,Apto,EntreCalle1,EntreCalle2,Rpto,Municipio,TelefonoParticular,TelefonoTrabajo,Control,Ruta,Folio")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: /Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: /Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult ValidarCi(string ci, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                if (!db.Clientes.Any(i => i.Ci == ci))
                {

                    result = true;
                }
            }
            else
            {
                if (!db.Clientes.Any(i => i.Ci.ToLower() == ci.ToLower() && i.Id != id))
                {
                   
                        result = true;
                   
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //private bool IsValidCi(string ci)
        //{
        //    var año = int.Parse(ci.Substring(0, 1));
        //    var mes = int.Parse(ci.Substring(2, 3));
        //    var dia = int.Parse(ci.Substring(4, 5));
        //    var fecha = new DateTime(año,mes,dia);
        //    return fecha.Year == año && fecha.Month == mes && fecha.Day == dia;
        //}

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
