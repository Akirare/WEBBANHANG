using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Controllers
{
    public class OrderController : Controller
    {
      
  

        public ActionResult GioHang()
        {
            ViewBag.Message = "Trang giỏ hàng";
            return View();
        }

        public ActionResult Checkout()
        {
            ViewBag.Message = "Trang thanh toán";
            return View();
        }



    }
}