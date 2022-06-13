using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_LePhamPhuongNam.Models;

namespace KiemTra_LePhamPhuongNam.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        Test01DataContext data = new Test01DataContext();
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(string id, FormCollection collection, SinhVien sv)
        {
            if (ModelState.IsValid)
            {
                var f_MaSV = collection["MaSv"] ;
                var E_data = data.SinhViens.Where(s => s.MaSV.Equals(f_MaSV)).ToList();
                if (data != null)
                {
                   
                    return RedirectToAction("ListSinhVien");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return this.DangNhap();
        }
    }
}