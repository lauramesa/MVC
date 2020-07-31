using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class tbl_plato_carnesController : Controller
    {
        private recetario_RendonMesaEntities db = new recetario_RendonMesaEntities();

        // GET: tbl_plato_carnes
        public ActionResult Index()
        {
            var tbl_plato_carnes = db.tbl_plato_carnes.Include(t => t.tbl_reseta);
            return View(tbl_plato_carnes.ToList());
        }

        // GET: tbl_plato_carnes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_plato_carnes tbl_plato_carnes = db.tbl_plato_carnes.Find(id);
            if (tbl_plato_carnes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_plato_carnes);
        }

        // GET: tbl_plato_carnes/Create
        public ActionResult Create()
        {
            ViewBag.idresetac = new SelectList(db.tbl_reseta, "idreseta", "nomplato");
            return View();
        }

        // POST: tbl_plato_carnes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idc,idresetac,nomplatoc,preciouc")] tbl_plato_carnes tbl_plato_carnes)
        {
            if (ModelState.IsValid)
            {
                db.tbl_plato_carnes.Add(tbl_plato_carnes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idresetac = new SelectList(db.tbl_reseta, "idreseta", "nomplato", tbl_plato_carnes.idresetac);
            return View(tbl_plato_carnes);
        }

        // GET: tbl_plato_carnes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_plato_carnes tbl_plato_carnes = db.tbl_plato_carnes.Find(id);
            if (tbl_plato_carnes == null)
            {
                return HttpNotFound();
            }
            ViewBag.idresetac = new SelectList(db.tbl_reseta, "idreseta", "nomplato", tbl_plato_carnes.idresetac);
            return View(tbl_plato_carnes);
        }

        // POST: tbl_plato_carnes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idc,idresetac,nomplatoc,preciouc")] tbl_plato_carnes tbl_plato_carnes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_plato_carnes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idresetac = new SelectList(db.tbl_reseta, "idreseta", "nomplato", tbl_plato_carnes.idresetac);
            return View(tbl_plato_carnes);
        }

        // GET: tbl_plato_carnes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_plato_carnes tbl_plato_carnes = db.tbl_plato_carnes.Find(id);
            if (tbl_plato_carnes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_plato_carnes);
        }

        // POST: tbl_plato_carnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_plato_carnes tbl_plato_carnes = db.tbl_plato_carnes.Find(id);
            db.tbl_plato_carnes.Remove(tbl_plato_carnes);
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
