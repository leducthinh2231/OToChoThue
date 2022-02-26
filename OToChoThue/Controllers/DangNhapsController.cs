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
    public class DangNhapsController : Controller
    {
        private OtoChoThueEntities db = new OtoChoThueEntities();
        // GET: DangNhap
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DangNhap objUser)
        {
            if (ModelState.IsValid)
            {


                var obj = db.DangNhap.Where(a => a.TaiKhoan.Equals(objUser.TaiKhoan) && a.MatKhau.Equals(objUser.MatKhau)).FirstOrDefault();
                if (obj != null)
                {
                    Session["TaiKhoan"] = obj.TaiKhoan.ToString();
                    return RedirectToAction("Index", "DonThueXes");
                }

                else
                {
                    ViewBag.Error = "The username or password is incorrect";
                    return View("Index");
                }
            }
            return View();
        }



    }
}