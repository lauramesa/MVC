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
    public class tbl_plato_postreController : Controller
    {
        private recetario_RendonMesaEntities db = new recetario_RendonMesaEntities();

        // GET: tbl_plato_postre
        public ActionResult Index()
        {
            var tbl_plato_postre = db.tbl_plato_postre.Include(t => t.tbl_reseta);
            return View(tbl_plato_postre.ToList());
        }

        // GET: tbl_plato_postre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_plato_postre tbl_plato_postre = db.tbl_plato_postre.Find(id);
            if (tbl_plato_postre == null)
            {
                return HttpNotFound();
            }
            return View(tbl_plato_postre);
        }

        // GET: tbl_plato_postre/Create
        public ActionResult Create()
        {
            ViewBag.idresetap = new SelectList(db.tbl_reseta, "idreseta", "nomplato");
            return View();
        }

        // POST: tbl_plato_postre/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idp,idresetap,nomplatop,precioup")] tbl_plato_postre tbl_plato_postre)
        {
            if (ModelState.IsValid)
            {
                db.tbl_plato_postre.Add(tbl_plato_postre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idresetap = new SelectList(db.tbl_reseta, "idreseta", "nomplato", tbl_plato_postre.idresetap);
            return View(tbl_plato_postre);
        }

        // GET: tbl_plato_postre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_plato_postre tbl_plato_postre = db.tbl_plato_postre.Find(id);
            if (tbl_plato_postre == null)
            {
                return HttpNotFound();
            }
            ViewBag.idresetap = new SelectList(db.tbl_reseta, "idreseta", "nomplato", tbl_plato_postre.idresetap);
            return View(tbl_plato_postre);
        }

        // POST: tbl_plato_postre/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idp,idresetap,nomplatop,precioup")] tbl_plato_postre tbl_plato_postre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_plato_postre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idresetap = new SelectList(db.tbl_reseta, "idreseta", "nomplato", tbl_plato_postre.idresetap);
            return View(tbl_plato_postre);
        }

        // GET: tbl_plato_postre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_plato_postre tbl_plato_postre = db.tbl_plato_postre.Find(id);
            if (tbl_plato_postre == null)
            {
                return HttpNotFound();
            }
            return View(tbl_plato_postre);
        }

        // POST: tbl_plato_postre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_plato_postre tbl_plato_postre = db.tbl_plato_postre.Find(id);
            db.tbl_plato_postre.Remove(tbl_plato_postre);
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
