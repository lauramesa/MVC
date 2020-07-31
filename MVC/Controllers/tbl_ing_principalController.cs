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
    public class tbl_ing_principalController : Controller
    {
        private recetario_RendonMesaEntities db = new recetario_RendonMesaEntities();

        // GET: tbl_ing_principal
        public ActionResult Index()
        {
            return View(db.tbl_ing_principal.ToList());
        }

        // GET: tbl_ing_principal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ing_principal tbl_ing_principal = db.tbl_ing_principal.Find(id);
            if (tbl_ing_principal == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ing_principal);
        }

        // GET: tbl_ing_principal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_ing_principal/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iding,ingrp")] tbl_ing_principal tbl_ing_principal)
        {
            if (ModelState.IsValid)
            {
                db.tbl_ing_principal.Add(tbl_ing_principal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_ing_principal);
        }

        // GET: tbl_ing_principal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ing_principal tbl_ing_principal = db.tbl_ing_principal.Find(id);
            if (tbl_ing_principal == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ing_principal);
        }

        // POST: tbl_ing_principal/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iding,ingrp")] tbl_ing_principal tbl_ing_principal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_ing_principal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_ing_principal);
        }

        // GET: tbl_ing_principal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ing_principal tbl_ing_principal = db.tbl_ing_principal.Find(id);
            if (tbl_ing_principal == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ing_principal);
        }

        // POST: tbl_ing_principal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_ing_principal tbl_ing_principal = db.tbl_ing_principal.Find(id);
            db.tbl_ing_principal.Remove(tbl_ing_principal);
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
