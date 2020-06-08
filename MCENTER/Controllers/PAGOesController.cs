using System;
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
    public class PAGOesController : Controller
    {
        private MCENTEREntities4 db = new MCENTEREntities4();

        // GET: PAGOes
        public ActionResult Index()
        {
            var pAGO = db.PAGO.Include(p => p.Venta);
            return View(pAGO.ToList());
        }

        // GET: PAGOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAGO pAGO = db.PAGO.Find(id);
            if (pAGO == null)
            {
                return HttpNotFound();
            }
            return View(pAGO);
        }

        // GET: PAGOes/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Venta, "Id", "Id");
            return View();
        }

        // POST: PAGOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pago,Id,tarjeta,fecharVencimiento,titular")] PAGO pAGO)
        {
            if (ModelState.IsValid)
            {
                db.PAGO.Add(pAGO);
                db.SaveChanges();
                return RedirectToAction("CompraFinalizada");
            }

            ViewBag.Id = new SelectList(db.Venta, "Id", "Id", pAGO.Id);
            return View(pAGO);
        }

        // GET: PAGOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAGO pAGO = db.PAGO.Find(id);
            if (pAGO == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Venta, "Id", "Id", pAGO.Id);
            return View(pAGO);
        }

        // POST: PAGOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pago,Id,tarjeta,fecharVencimiento,titular")] PAGO pAGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAGO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Venta, "Id", "Id", pAGO.Id);
            return View(pAGO);
        }

        // GET: PAGOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAGO pAGO = db.PAGO.Find(id);
            if (pAGO == null)
            {
                return HttpNotFound();
            }
            return View(pAGO);
        }

        public ActionResult CompraFinalizada()
        {
         
            return View();
        }

        // POST: PAGOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAGO pAGO = db.PAGO.Find(id);
            db.PAGO.Remove(pAGO);
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
