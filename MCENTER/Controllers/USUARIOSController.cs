﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MCENTER.Models;

namespace MCENTER.Controllers
{
    public class USUARIOSController : Controller
    {
        private MCENTEREntities4 db = new MCENTEREntities4();

        // GET: USUARIOS
        public ActionResult Index()
        {
            var uSUARIOS = db.USUARIOS.Include(u => u.ROLES);
            return View(uSUARIOS.ToList());
        }

        // GET: USUARIOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIOS uSUARIOS = db.USUARIOS.Find(id);
            if (uSUARIOS == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIOS);
        }

        // GET: USUARIOS/Create
        public ActionResult Create()
        {
            ViewBag.id_rol = new SelectList(db.ROLES, "id_rol", "rol");
            return View();
        }

        public ActionResult Registro()
        {
            ViewBag.id_rol = new SelectList(db.ROLES, "id_rol", "rol");
            return View();
        }

        // POST: USUARIOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro([Bind(Include = "id_usuario,6,usuario,clave")] USUARIOS uSUARIOS)
        {
            if (ModelState.IsValid)
            {
                db.USUARIOS.Add(uSUARIOS);
                db.SaveChanges();

                return RedirectToAction("Login", "Login");
               

            }

            ViewBag.id_rol = 6;
            return View(uSUARIOS);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_usuario,id_rol,usuario,clave")] USUARIOS uSUARIOS)
        {
            if (ModelState.IsValid)
            {
                db.USUARIOS.Add(uSUARIOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_rol = new SelectList(db.ROLES, "id_rol", "rol", uSUARIOS.id_rol);
            return View(uSUARIOS);
        }

        // GET: USUARIOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIOS uSUARIOS = db.USUARIOS.Find(id);
            if (uSUARIOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_rol = new SelectList(db.ROLES, "id_rol", "rol", uSUARIOS.id_rol);
            return View(uSUARIOS);
        }

        // POST: USUARIOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_usuario,id_rol,usuario,clave")] USUARIOS uSUARIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_rol = new SelectList(db.ROLES, "id_rol", "rol", uSUARIOS.id_rol);
            return View(uSUARIOS);
        }

        // GET: USUARIOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIOS uSUARIOS = db.USUARIOS.Find(id);
            if (uSUARIOS == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIOS);
        }

        // POST: USUARIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIOS uSUARIOS = db.USUARIOS.Find(id);
            db.USUARIOS.Remove(uSUARIOS);
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
