using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Egresados.Models;

namespace Egresados.Controllers
{
    public class RegistrarEmpresasController : Controller
    {
        private EgresadosContext db = new EgresadosContext();

        // GET: RegistrarEmpresas
        public ActionResult Index()
        {
            return View(db.RegistrarEmpresas.ToList());
        }

        // GET: RegistrarEmpresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrarEmpresa registrarEmpresa = db.RegistrarEmpresas.Find(id);
            if (registrarEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(registrarEmpresa);
        }

        // GET: RegistrarEmpresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrarEmpresas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegistrarEmpresaID,NombreEmpresa")] RegistrarEmpresa registrarEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.RegistrarEmpresas.Add(registrarEmpresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registrarEmpresa);
        }

        // GET: RegistrarEmpresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrarEmpresa registrarEmpresa = db.RegistrarEmpresas.Find(id);
            if (registrarEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(registrarEmpresa);
        }

        // POST: RegistrarEmpresas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistrarEmpresaID,NombreEmpresa")] RegistrarEmpresa registrarEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrarEmpresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registrarEmpresa);
        }

        // GET: RegistrarEmpresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrarEmpresa registrarEmpresa = db.RegistrarEmpresas.Find(id);
            if (registrarEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(registrarEmpresa);
        }

        // POST: RegistrarEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistrarEmpresa registrarEmpresa = db.RegistrarEmpresas.Find(id);
            db.RegistrarEmpresas.Remove(registrarEmpresa);
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
