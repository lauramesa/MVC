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
    public class tbl_pasosController : Controller
    {
        private recetario_RendonMesaEntities db = new recetario_RendonMesaEntities();

        // GET: tbl_pasos
        public ActionResult Index()
        {
            return View(db.tbl_pasos.ToList());
        }

        // GET: tbl_pasos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_pasos tbl_pasos = db.tbl_pasos.Find(id);
            if (tbl_pasos == null)
            {
                return HttpNotFound();
            }
            return View(tbl_pasos);
        }

        // GET: tbl_pasos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_pasos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idpas,paso1,timp1,paso2,timp2,paso3,timp3,paso4,timp4,paso5,timp5,paso6,timp6,paso7,timp7,comentario")] tbl_pasos tbl_pasos)
        {
            if (ModelState.IsValid)
            {
                db.tbl_pasos.Add(tbl_pasos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_pasos);
        }

        // GET: tbl_pasos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_pasos tbl_pasos = db.tbl_pasos.Find(id);
            if (tbl_pasos == null)
            {
                return HttpNotFound();
            }
            return View(tbl_pasos);
        }

        // POST: tbl_pasos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idpas,paso1,timp1,paso2,timp2,paso3,timp3,paso4,timp4,paso5,timp5,paso6,timp6,paso7,timp7,comentario")] tbl_pasos tbl_pasos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_pasos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_pasos);
        }

        // GET: tbl_pasos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_pasos tbl_pasos = db.tbl_pasos.Find(id);
            if (tbl_pasos == null)
            {
                return HttpNotFound();
            }
            return View(tbl_pasos);
        }

        // POST: tbl_pasos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_pasos tbl_pasos = db.tbl_pasos.Find(id);
            db.tbl_pasos.Remove(tbl_pasos);
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
