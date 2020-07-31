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
    public class tbl_inf_originalController : Controller
    {
        private recetario_RendonMesaEntities db = new recetario_RendonMesaEntities();

        // GET: tbl_inf_original
        public ActionResult Index()
        {
            var tbl_inf_original = db.tbl_inf_original.Include(t => t.tbl_reseta);
            return View(tbl_inf_original.ToList());
        }

        // GET: tbl_inf_original/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_inf_original tbl_inf_original = db.tbl_inf_original.Find(id);
            if (tbl_inf_original == null)
            {
                return HttpNotFound();
            }
            return View(tbl_inf_original);
        }

        // GET: tbl_inf_original/Create
        public ActionResult Create()
        {
            ViewBag.serier = new SelectList(db.tbl_reseta, "idreseta", "nomplato");
            return View();
        }

        // POST: tbl_inf_original/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idoc,serier,fuente,ubicacion")] tbl_inf_original tbl_inf_original)
        {
            if (ModelState.IsValid)
            {
                db.tbl_inf_original.Add(tbl_inf_original);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.serier = new SelectList(db.tbl_reseta, "idreseta", "nomplato", tbl_inf_original.serier);
            return View(tbl_inf_original);
        }

        // GET: tbl_inf_original/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_inf_original tbl_inf_original = db.tbl_inf_original.Find(id);
            if (tbl_inf_original == null)
            {
                return HttpNotFound();
            }
            ViewBag.serier = new SelectList(db.tbl_reseta, "idreseta", "nomplato", tbl_inf_original.serier);
            return View(tbl_inf_original);
        }

        // POST: tbl_inf_original/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idoc,serier,fuente,ubicacion")] tbl_inf_original tbl_inf_original)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_inf_original).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.serier = new SelectList(db.tbl_reseta, "idreseta", "nomplato", tbl_inf_original.serier);
            return View(tbl_inf_original);
        }

        // GET: tbl_inf_original/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_inf_original tbl_inf_original = db.tbl_inf_original.Find(id);
            if (tbl_inf_original == null)
            {
                return HttpNotFound();
            }
            return View(tbl_inf_original);
        }

        // POST: tbl_inf_original/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_inf_original tbl_inf_original = db.tbl_inf_original.Find(id);
            db.tbl_inf_original.Remove(tbl_inf_original);
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
