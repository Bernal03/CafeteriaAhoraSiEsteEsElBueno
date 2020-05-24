using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CafeteriaAhoraSiEsteEsElBueno.Models;

namespace CafeteriaAhoraSiEsteEsElBueno.Controllers
{
    public class PedidsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pedids
        public ActionResult Index()
        {
            var pedids = db.Pedids.Include(p => p.Product);
            return View(pedids.ToList());
        }

        // GET: Pedids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedid pedid = db.Pedids.Find(id);
            if (pedid == null)
            {
                return HttpNotFound();
            }
            return View(pedid);
        }

        // GET: Pedids/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "NombreProducto");
            return View();
        }

        // POST: Pedids/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreCliente,ProductId")] Pedid pedid)
        {
            if (ModelState.IsValid)
            {
                db.Pedids.Add(pedid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "NombreProducto", pedid.ProductId);
            return View(pedid);
        }

        // GET: Pedids/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedid pedid = db.Pedids.Find(id);
            if (pedid == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "NombreProducto", pedid.ProductId);
            return View(pedid);
        }

        // POST: Pedids/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreCliente,ProductId")] Pedid pedid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "NombreProducto", pedid.ProductId);
            return View(pedid);
        }

        // GET: Pedids/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedid pedid = db.Pedids.Find(id);
            if (pedid == null)
            {
                return HttpNotFound();
            }
            return View(pedid);
        }

        // POST: Pedids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedid pedid = db.Pedids.Find(id);
            db.Pedids.Remove(pedid);
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
