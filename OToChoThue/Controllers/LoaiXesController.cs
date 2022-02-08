using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OToChoThue.Models;

namespace OToChoThue.Controllers
{
    public class LoaiXesController : Controller
    {
        private OtoChoThueEntities db = new OtoChoThueEntities();

        // GET: LoaiXes
        public ActionResult Index()
        {
            return View(db.LoaiXes.ToList());
        }

        // GET: LoaiXes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiXe loaiXe = db.LoaiXes.Find(id);
            if (loaiXe == null)
            {
                return HttpNotFound();
            }
            return View(loaiXe);
        }

        // GET: LoaiXes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiXes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "XeID,TenXe,BienSo,GiaThue")] LoaiXe loaiXe)
        {
            if (ModelState.IsValid)
            {
                db.LoaiXes.Add(loaiXe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiXe);
        }

        // GET: LoaiXes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiXe loaiXe = db.LoaiXes.Find(id);
            if (loaiXe == null)
            {
                return HttpNotFound();
            }
            return View(loaiXe);
        }

        // POST: LoaiXes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "XeID,TenXe,BienSo,GiaThue")] LoaiXe loaiXe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiXe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiXe);
        }

        // GET: LoaiXes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiXe loaiXe = db.LoaiXes.Find(id);
            if (loaiXe == null)
            {
                return HttpNotFound();
            }
            return View(loaiXe);
        }

        // POST: LoaiXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiXe loaiXe = db.LoaiXes.Find(id);
            db.LoaiXes.Remove(loaiXe);
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
