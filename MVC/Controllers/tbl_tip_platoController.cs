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
    public class tbl_tip_platoController : Controller
    {
        private recetario_RendonMesaEntities db = new recetario_RendonMesaEntities();

        // GET: tbl_tip_plato
        public ActionResult Index()
        {
            return View(db.tbl_tip_plato.ToList());
        }

        // GET: tbl_tip_plato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_tip_plato tbl_tip_plato = db.tbl_tip_plato.Find(id);
            if (tbl_tip_plato == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tip_plato);
        }

        // GET: tbl_tip_plato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_tip_plato/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtplato,tipo_plato")] tbl_tip_plato tbl_tip_plato)
        {
            if (ModelState.IsValid)
            {
                db.tbl_tip_plato.Add(tbl_tip_plato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_tip_plato);
        }

        // GET: tbl_tip_plato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_tip_plato tbl_tip_plato = db.tbl_tip_plato.Find(id);
            if (tbl_tip_plato == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tip_plato);
        }

        // POST: tbl_tip_plato/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtplato,tipo_plato")] tbl_tip_plato tbl_tip_plato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_tip_plato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_tip_plato);
        }

        // GET: tbl_tip_plato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_tip_plato tbl_tip_plato = db.tbl_tip_plato.Find(id);
            if (tbl_tip_plato == null)
            {
                return HttpNotFound();
            }
            return View(tbl_tip_plato);
        }

        // POST: tbl_tip_plato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_tip_plato tbl_tip_plato = db.tbl_tip_plato.Find(id);
            db.tbl_tip_plato.Remove(tbl_tip_plato);
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
