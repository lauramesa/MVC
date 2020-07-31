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
    public class tbl_plato_vegetalesController : Controller
    {
        private recetario_RendonMesaEntities db = new recetario_RendonMesaEntities();

        // GET: tbl_plato_vegetales
        public ActionResult Index()
        {
            var tbl_plato_vegetales = db.tbl_plato_vegetales.Include(t => t.tbl_reseta);
            return View(tbl_plato_vegetales.ToList());
        }

        // GET: tbl_plato_vegetales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_plato_vegetales tbl_plato_vegetales = db.tbl_plato_vegetales.Find(id);
            if (tbl_plato_vegetales == null)
            {
                return HttpNotFound();
            }
            return View(tbl_plato_vegetales);
        }

        // GET: tbl_plato_vegetales/Create
        public ActionResult Create()
        {
            ViewBag.idresetav = new SelectList(db.tbl_reseta, "idreseta", "nomplato");
            return View();
        }

        // POST: tbl_plato_vegetales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idv,idresetav,nomplatov,preciouv")] tbl_plato_vegetales tbl_plato_vegetales)
        {
            if (ModelState.IsValid)
            {
                db.tbl_plato_vegetales.Add(tbl_plato_vegetales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idresetav = new SelectList(db.tbl_reseta, "idreseta", "nomplato", tbl_plato_vegetales.idresetav);
            return View(tbl_plato_vegetales);
        }

        // GET: tbl_plato_vegetales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_plato_vegetales tbl_plato_vegetales = db.tbl_plato_vegetales.Find(id);
            if (tbl_plato_vegetales == null)
            {
                return HttpNotFound();
            }
            ViewBag.idresetav = new SelectList(db.tbl_reseta, "idreseta", "nomplato", tbl_plato_vegetales.idresetav);
            return View(tbl_plato_vegetales);
        }

        // POST: tbl_plato_vegetales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idv,idresetav,nomplatov,preciouv")] tbl_plato_vegetales tbl_plato_vegetales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_plato_vegetales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idresetav = new SelectList(db.tbl_reseta, "idreseta", "nomplato", tbl_plato_vegetales.idresetav);
            return View(tbl_plato_vegetales);
        }

        // GET: tbl_plato_vegetales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_plato_vegetales tbl_plato_vegetales = db.tbl_plato_vegetales.Find(id);
            if (tbl_plato_vegetales == null)
            {
                return HttpNotFound();
            }
            return View(tbl_plato_vegetales);
        }

        // POST: tbl_plato_vegetales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_plato_vegetales tbl_plato_vegetales = db.tbl_plato_vegetales.Find(id);
            db.tbl_plato_vegetales.Remove(tbl_plato_vegetales);
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
