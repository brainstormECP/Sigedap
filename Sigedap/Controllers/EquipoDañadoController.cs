using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Sigedap.Models;

namespace Sigedap.Controllers
{
    public class EquipoDañadoController : Controller
    {
        SigedapContext _db = new SigedapContext(); 
        
        //
        // GET: /EquipoDañado/Lista/5
        public JsonResult Lista(int id)
        {
            var lista = _db.EquiposDañados.Include(e => e.Marca).Include(e => e.TipoDeEquipo).
                Where(e => e.ExpedienteDictamenDeReclamacionId == id).
                Select(e => new { e.Id, e.TipoDeEquipoId, NombreTipoDeEquipo = e.TipoDeEquipo.Nombre ,NombreMarca = e.Marca.Nombre, e.MarcaId ,e.Modelo, e.Nacionalidad, e.Serie, e.Descripcion, e.ExpedienteDictamenDeReclamacionId});
            var equipos = lista.ToList();
            
            return Json(equipos, JsonRequestBehavior.AllowGet);
        }
        
        //
        // POST: /EquipoDañado/Create
        [HttpPost]
        public ActionResult Crear(EquipoDañado equipo)
        {
            if (ModelState.IsValid)
            {
                _db.EquiposDañados.Add(equipo);
                _db.SaveChanges();
                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, friend);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = friend.FriendId }));
                //return response;
                var tipoEq = _db.TiposDeEquipos.Single(t => t.Id == equipo.TipoDeEquipoId).Nombre;
                var marca = _db.Marcas.Single(t => t.Id == equipo.MarcaId).Nombre;
                var id = equipo.Id;
                return Json(new {Id = id, NombreTipoDeEquipo = tipoEq, NombreMarca = marca });
            }
            else
            {
                return Json(false);
                //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }   
        }
       
        //
        // POST: /EquipoDañado/Edit/5
        [HttpPost]
        public ActionResult Editar(EquipoDañado equipo)
        {
            if (ModelState.IsValid)
            {
                var eq = _db.EquiposDañados.Find(equipo.Id);
                eq.MarcaId = equipo.MarcaId;
                eq.Modelo = equipo.Modelo;
                eq.Serie = equipo.Serie;
                eq.TipoDeEquipoId = equipo.TipoDeEquipoId;
                eq.Descripcion = equipo.Descripcion;
                eq.Nacionalidad = equipo.Nacionalidad;
                _db.SaveChanges();
                var tipoEq = _db.TiposDeEquipos.Single(t => t.Id == equipo.TipoDeEquipoId).Nombre;
                var marca = _db.Marcas.Single(t => t.Id == equipo.MarcaId).Nombre;
                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, friend);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = friend.FriendId }));
                //return response;
                return Json(new { NombreTipoDeEquipo = tipoEq, NombreMarca = marca });
            }
            else
            {
                return Json(false);
                //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }   
        }
       
        //
        // POST: /EquipoDañado/Delete/5
        public ActionResult Eliminar(int? id)
        {
            if (id != null)
            {
                var equipo = _db.EquiposDañados.Find(id);
                _db.EquiposDañados.Remove(equipo);
                _db.SaveChanges();
                return Json(true,JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false);
                //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }   
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
