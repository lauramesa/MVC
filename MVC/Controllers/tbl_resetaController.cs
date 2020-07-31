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
    public class tbl_resetaController : Controller
    {
        private recetario_RendonMesaEntities db = new recetario_RendonMesaEntities();

        // GET: tbl_reseta
        public ActionResult Index()
        {
            var tbl_reseta = db.tbl_reseta.Include(t => t.tbl_ing_principal).Include(t => t.tbl_list_ingredientes).Include(t => t.tbl_pasos).Include(t => t.tbl_tip_plato);
            return View(tbl_reseta.ToList());
        }

        // GET: tbl_reseta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_reseta tbl_reseta = db.tbl_reseta.Find(id);
            if (tbl_reseta == null)
            {
                return HttpNotFound();
            }
            return View(tbl_reseta);
        }

        // GET: tbl_reseta/Create
        public ActionResult Create()
        {
            ViewBag.ingpp = new SelectList(db.tbl_ing_principal, "iding", "ingrp");
            ViewBag.listing = new SelectList(db.tbl_list_ingredientes, "idlist", "ingredientes");
            ViewBag.idpasos = new SelectList(db.tbl_pasos, "idpas", "paso1");
            ViewBag.tpp = new SelectList(db.tbl_tip_plato, "idtplato", "tipo_plato");
            return View();
        }

        // POST: tbl_reseta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idreseta,tpp,nomplato,idpasos,timtotal,calorias,listing,ingpp,utencilios,comentario_descrip")] tbl_reseta tbl_reseta)
        {
            if (ModelState.IsValid)
            {
                db.tbl_reseta.Add(tbl_reseta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ingpp = new SelectList(db.tbl_ing_principal, "iding", "ingrp", tbl_reseta.ingpp);
            ViewBag.listing = new SelectList(db.tbl_list_ingredientes, "idlist", "ingredientes", tbl_reseta.listing);
            ViewBag.idpasos = new SelectList(db.tbl_pasos, "idpas", "paso1", tbl_reseta.idpasos);
            ViewBag.tpp = new SelectList(db.tbl_tip_plato, "idtplato", "tipo_plato", tbl_reseta.tpp);
            return View(tbl_reseta);
        }

        // GET: tbl_reseta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_reseta tbl_reseta = db.tbl_reseta.Find(id);
            if (tbl_reseta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ingpp = new SelectList(db.tbl_ing_principal, "iding", "ingrp", tbl_reseta.ingpp);
            ViewBag.listing = new SelectList(db.tbl_list_ingredientes, "idlist", "ingredientes", tbl_reseta.listing);
            ViewBag.idpasos = new SelectList(db.tbl_pasos, "idpas", "paso1", tbl_reseta.idpasos);
            ViewBag.tpp = new SelectList(db.tbl_tip_plato, "idtplato", "tipo_plato", tbl_reseta.tpp);
            return View(tbl_reseta);
        }

        // POST: tbl_reseta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idreseta,tpp,nomplato,idpasos,timtotal,calorias,listing,ingpp,utencilios,comentario_descrip")] tbl_reseta tbl_reseta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_reseta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ingpp = new SelectList(db.tbl_ing_principal, "iding", "ingrp", tbl_reseta.ingpp);
            ViewBag.listing = new SelectList(db.tbl_list_ingredientes, "idlist", "ingredientes", tbl_reseta.listing);
            ViewBag.idpasos = new SelectList(db.tbl_pasos, "idpas", "paso1", tbl_reseta.idpasos);
            ViewBag.tpp = new SelectList(db.tbl_tip_plato, "idtplato", "tipo_plato", tbl_reseta.tpp);
            return View(tbl_reseta);
        }

        // GET: tbl_reseta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_reseta tbl_reseta = db.tbl_reseta.Find(id);
            if (tbl_reseta == null)
            {
                return HttpNotFound();
            }
            return View(tbl_reseta);
        }

        // POST: tbl_reseta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_reseta tbl_reseta = db.tbl_reseta.Find(id);
            db.tbl_reseta.Remove(tbl_reseta);
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
