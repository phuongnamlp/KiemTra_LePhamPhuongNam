using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_LePhamPhuongNam.Models;

namespace KiemTra_LePhamPhuongNam.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        Test01DataContext data = new Test01DataContext();
        public ActionResult ListSinhVien()
        {
            var all_sinhvien = from ss in data.SinhViens select ss;
            return View(all_sinhvien);
        }
        public ActionResult Detail(string id)
        {
            var sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(sinhvien);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien sv)
        {
            var E_MaSV = collection["MaSV"];
            var E_Hoten = collection["HoTen"];
            var E_Gioitinh = collection["GioiTinh"];
            var E_NgaySinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_Hinh = collection["Hinh"];
            var E_Nghanh = collection["MaNghanh"];
            if (string.IsNullOrEmpty(E_MaSV))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sv.MaSV = E_MaSV.ToString();
                sv.Hinh = E_Hinh.ToString();
                sv.HoTen = E_Hoten;
                sv.GioiTinh = E_Gioitinh;
                sv.MaNganh = E_Nghanh;
                sv.NgaySinh = E_NgaySinh;
                data.SinhViens.InsertOnSubmit(sv);
                data.SubmitChanges();
                return RedirectToAction("ListSinhVien");
            }
            return this.Create();
        }
        public ActionResult Edit(string id)
        {
            var E_sinhVien= data.SinhViens.First(m => m.MaSV == id);
            return View(E_sinhVien);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_MaSV = data.SinhViens.First(m => m.MaSV == id);
            var E_Hoten = collection["HoTen"];
            var E_Gioitinh = collection["GioiTinh"];
            var E_NgaySinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_Hinh = collection["Hinh"];
            var E_Nghanh = collection["MaNghanh"];
            E_MaSV.MaSV = id;
            if (string.IsNullOrEmpty(E_Hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_MaSV.HoTen = E_Hoten.ToString();
                E_MaSV.GioiTinh = E_Gioitinh.ToString();
                E_MaSV.NgaySinh = E_NgaySinh;
                E_MaSV.Hinh = E_Hinh.ToString();
                E_MaSV.MaNganh = E_Nghanh.ToString();
                UpdateModel(E_MaSV);
                data.SubmitChanges();
                return RedirectToAction("ListSinhVien");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(string id)
        {
            var D_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            return View(D_sinhvien);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_sinhvien);
            data.SubmitChanges();
            return RedirectToAction("ListSinhVien");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
    }
}