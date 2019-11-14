using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.EFF;

namespace WebBanHang.Controllers
{
    public class PageController : Controller
    {
        public ActionResult Index()
        {
            List<products> lstProduct = new List<products>();

            using (QuanLyBanHangEntities context = new QuanLyBanHangEntities()) 
            {
                lstProduct = context.products.ToList();
            }
            // Truyền dữ liệu từ controller => View thông qua viewBag
            //Tên View mới DanhSachSanPham
            ViewBag.DanhSachSanPham = lstProduct;

            return View();
        }
        
        public ActionResult GioiThieu()
        {
            ViewBag.Message = "Trang giới thiệu";

            return View();
        }

        public ActionResult LienHe()
        {
            ViewBag.Message = "Trang liên hệ";

            return View();
        }
 

        public ActionResult DangNhap()
        {
            return View();
        }

        public ActionResult DangKy()
        {
            return View();
        }

        public ActionResult ChinhSach()
        {
            return View();
        }
    }
}