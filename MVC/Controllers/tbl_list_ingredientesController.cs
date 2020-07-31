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
    public class tbl_list_ingredientesController : Controller
    {
        private recetario_RendonMesaEntities db = new recetario_RendonMesaEntities();

        // GET: tbl_list_ingredientes
        public ActionResult Index()
        {
            return View(db.tbl_list_ingredientes.ToList());
        }

        // GET: tbl_list_ingredientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_list_ingredientes tbl_list_ingredientes = db.tbl_list_ingredientes.Find(id);
            if (tbl_list_ingredientes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_list_ingredientes);
        }

        // GET: tbl_list_ingredientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_list_ingredientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idlist,ingredientes,cantidades")] tbl_list_ingredientes tbl_list_ingredientes)
        {
            if (ModelState.IsValid)
            {
                db.tbl_list_ingredientes.Add(tbl_list_ingredientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_list_ingredientes);
        }

        // GET: tbl_list_ingredientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_list_ingredientes tbl_list_ingredientes = db.tbl_list_ingredientes.Find(id);
            if (tbl_list_ingredientes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_list_ingredientes);
        }

        // POST: tbl_list_ingredientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idlist,ingredientes,cantidades")] tbl_list_ingredientes tbl_list_ingredientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_list_ingredientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_list_ingredientes);
        }

        // GET: tbl_list_ingredientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_list_ingredientes tbl_list_ingredientes = db.tbl_list_ingredientes.Find(id);
            if (tbl_list_ingredientes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_list_ingredientes);
        }

        // POST: tbl_list_ingredientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_list_ingredientes tbl_list_ingredientes = db.tbl_list_ingredientes.Find(id);
            db.tbl_list_ingredientes.Remove(tbl_list_ingredientes);
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
