using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_LePhamPhuongNam.Models;


namespace KiemTra_LePhamPhuongNam.Controllers
{
    public class HocPhanController : Controller
    {
        // GET: HocPhan
        Test01DataContext data = new Test01DataContext();
        public ActionResult ListHocPhan()
        {
            var all_hocphan = from ss in data.HocPhans select ss;
            return View(all_hocphan);
        }
    }
}