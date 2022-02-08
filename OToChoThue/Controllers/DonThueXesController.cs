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
    public class DonThueXesController : Controller
    {
        private OtoChoThueEntities db = new OtoChoThueEntities();

        // GET: DonThueXes
        public ActionResult Index()
        {
            var donThueXes = db.DonThueXes.Include(d => d.ThongTinKhachHang).Include(d => d.LoaiXe);
            return View(donThueXes.ToList());
        }

        // GET: DonThueXes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonThueXe donThueXe = db.DonThueXes.Find(id);
            if (donThueXe == null)
            {
                return HttpNotFound();
            }
            return View(donThueXe);
        }

        // GET: DonThueXes/Create
        public ActionResult Create()
        {
            ViewBag.KhachHangID = new SelectList(db.ThongTinKhachHangs, "KhachHangID", "HoTen");
            ViewBag.XeID = new SelectList(db.LoaiXes, "XeID", "TenXe");
            return View();
        }

        // POST: DonThueXes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonThueID,KhachHangID,XeID,NgayThue,NgayTra,TongTien")] DonThueXe donThueXe)
        {
            if (ModelState.IsValid)
            {
                db.DonThueXes.Add(donThueXe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KhachHangID = new SelectList(db.ThongTinKhachHangs, "KhachHangID", "HoTen", donThueXe.KhachHangID);
            ViewBag.XeID = new SelectList(db.LoaiXes, "XeID", "TenXe", donThueXe.XeID);
            return View(donThueXe);
        }

        // GET: DonThueXes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonThueXe donThueXe = db.DonThueXes.Find(id);
            if (donThueXe == null)
            {
                return HttpNotFound();
            }
            ViewBag.KhachHangID = new SelectList(db.ThongTinKhachHangs, "KhachHangID", "HoTen", donThueXe.KhachHangID);
            ViewBag.XeID = new SelectList(db.LoaiXes, "XeID", "TenXe", donThueXe.XeID);
            return View(donThueXe);
        }

        // POST: DonThueXes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonThueID,KhachHangID,XeID,NgayThue,NgayTra,TongTien")] DonThueXe donThueXe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donThueXe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KhachHangID = new SelectList(db.ThongTinKhachHangs, "KhachHangID", "HoTen", donThueXe.KhachHangID);
            ViewBag.XeID = new SelectList(db.LoaiXes, "XeID", "TenXe", donThueXe.XeID);
            return View(donThueXe);
        }

        // GET: DonThueXes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonThueXe donThueXe = db.DonThueXes.Find(id);
            if (donThueXe == null)
            {
                return HttpNotFound();
            }
            return View(donThueXe);
        }

        // POST: DonThueXes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonThueXe donThueXe = db.DonThueXes.Find(id);
            db.DonThueXes.Remove(donThueXe);
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
