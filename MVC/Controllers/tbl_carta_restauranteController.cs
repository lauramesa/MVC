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
    public class tbl_carta_restauranteController : Controller
    {
        private recetario_RendonMesaEntities db = new recetario_RendonMesaEntities();

        // GET: tbl_carta_restaurante
        public ActionResult Index()
        {
            var tbl_carta_restaurante = db.tbl_carta_restaurante.Include(t => t.tbl_plato_vegetales).Include(t => t.tbl_plato_carnes).Include(t => t.tbl_plato_postre);
            return View(tbl_carta_restaurante.ToList());
        }

        // GET: tbl_carta_restaurante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_carta_restaurante tbl_carta_restaurante = db.tbl_carta_restaurante.Find(id);
            if (tbl_carta_restaurante == null)
            {
                return HttpNotFound();
            }
            return View(tbl_carta_restaurante);
        }

        // GET: tbl_carta_restaurante/Create
        public ActionResult Create()
        {
            ViewBag.p1base = new SelectList(db.tbl_plato_vegetales, "idv", "nomplatov");
            ViewBag.p2principal = new SelectList(db.tbl_plato_carnes, "idc", "nomplatoc");
            ViewBag.postre = new SelectList(db.tbl_plato_postre, "idp", "nomplatop");
            return View();
        }

        // POST: tbl_carta_restaurante/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "menu,p1base,p2principal,postre,preciott,comentarioteveto")] tbl_carta_restaurante tbl_carta_restaurante)
        {
            if (ModelState.IsValid)
            {
                db.tbl_carta_restaurante.Add(tbl_carta_restaurante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.p1base = new SelectList(db.tbl_plato_vegetales, "idv", "nomplatov", tbl_carta_restaurante.p1base);
            ViewBag.p2principal = new SelectList(db.tbl_plato_carnes, "idc", "nomplatoc", tbl_carta_restaurante.p2principal);
            ViewBag.postre = new SelectList(db.tbl_plato_postre, "idp", "nomplatop", tbl_carta_restaurante.postre);
            return View(tbl_carta_restaurante);
        }

        // GET: tbl_carta_restaurante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_carta_restaurante tbl_carta_restaurante = db.tbl_carta_restaurante.Find(id);
            if (tbl_carta_restaurante == null)
            {
                return HttpNotFound();
            }
            ViewBag.p1base = new SelectList(db.tbl_plato_vegetales, "idv", "nomplatov", tbl_carta_restaurante.p1base);
            ViewBag.p2principal = new SelectList(db.tbl_plato_carnes, "idc", "nomplatoc", tbl_carta_restaurante.p2principal);
            ViewBag.postre = new SelectList(db.tbl_plato_postre, "idp", "nomplatop", tbl_carta_restaurante.postre);
            return View(tbl_carta_restaurante);
        }

        // POST: tbl_carta_restaurante/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "menu,p1base,p2principal,postre,preciott,comentarioteveto")] tbl_carta_restaurante tbl_carta_restaurante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_carta_restaurante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.p1base = new SelectList(db.tbl_plato_vegetales, "idv", "nomplatov", tbl_carta_restaurante.p1base);
            ViewBag.p2principal = new SelectList(db.tbl_plato_carnes, "idc", "nomplatoc", tbl_carta_restaurante.p2principal);
            ViewBag.postre = new SelectList(db.tbl_plato_postre, "idp", "nomplatop", tbl_carta_restaurante.postre);
            return View(tbl_carta_restaurante);
        }

        // GET: tbl_carta_restaurante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_carta_restaurante tbl_carta_restaurante = db.tbl_carta_restaurante.Find(id);
            if (tbl_carta_restaurante == null)
            {
                return HttpNotFound();
            }
            return View(tbl_carta_restaurante);
        }

        // POST: tbl_carta_restaurante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_carta_restaurante tbl_carta_restaurante = db.tbl_carta_restaurante.Find(id);
            db.tbl_carta_restaurante.Remove(tbl_carta_restaurante);
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
