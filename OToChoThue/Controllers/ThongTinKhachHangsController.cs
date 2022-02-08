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
    public class ThongTinKhachHangsController : Controller
    {
        private OtoChoThueEntities db = new OtoChoThueEntities();

        // GET: ThongTinKhachHangs
        public ActionResult Index()
        {
            return View(db.ThongTinKhachHangs.ToList());
        }

        // GET: ThongTinKhachHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinKhachHang thongTinKhachHang = db.ThongTinKhachHangs.Find(id);
            if (thongTinKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(thongTinKhachHang);
        }

        // GET: ThongTinKhachHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThongTinKhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KhachHangID,HoTen,DiaChi,SoDienThoai")] ThongTinKhachHang thongTinKhachHang)
        {
            if (ModelState.IsValid)
            {
                db.ThongTinKhachHangs.Add(thongTinKhachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thongTinKhachHang);
        }

        // GET: ThongTinKhachHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinKhachHang thongTinKhachHang = db.ThongTinKhachHangs.Find(id);
            if (thongTinKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(thongTinKhachHang);
        }

        // POST: ThongTinKhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KhachHangID,HoTen,DiaChi,SoDienThoai")] ThongTinKhachHang thongTinKhachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongTinKhachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thongTinKhachHang);
        }

        // GET: ThongTinKhachHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinKhachHang thongTinKhachHang = db.ThongTinKhachHangs.Find(id);
            if (thongTinKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(thongTinKhachHang);
        }

        // POST: ThongTinKhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ThongTinKhachHang thongTinKhachHang = db.ThongTinKhachHangs.Find(id);
            db.ThongTinKhachHangs.Remove(thongTinKhachHang);
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
