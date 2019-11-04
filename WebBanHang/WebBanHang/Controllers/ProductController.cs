using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Controllers
{
    public class ProductController : Controller
    {
      
  

        public ActionResult Index()
        {
       
            return View();
        }

        public ActionResult ProductDetail(int id)
        {
            ViewBag.Message = "Chi tiết sản phẩm";

            return View();
        }

    }
}