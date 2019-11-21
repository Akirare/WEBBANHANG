using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.EFF;
namespace WebBanHang.Controllers
{
    public class ProductController : Controller
    {
      
  

        public ActionResult Index()
        {
       
            return View();
        }

        public ActionResult ProductDetail(int idProduct)
        {

            products product = null;
              //Lay du lieu san pham
              using(QuanLyBanHangEntities context = new QuanLyBanHangEntities())
            {
     
                 product = context.products.Where(p => p.id == idProduct).FirstOrDefault();
            }
            // Truyen du lieu tu controller sang view
            ViewBag.SanPham = product;

            return View();

        }

    }
}