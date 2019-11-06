using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanHang
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Page.trang_chu",
              url: "",
              defaults: new { controller = "Page", action = "Index" }
          );

            routes.MapRoute(
               name: "Page.gioi_thieu",
               url: "gioi-thieu",
               defaults: new { controller = "Page", action = "GioiThieu"}
           );

            routes.MapRoute(
               name: "Page.lien_he",
               url: "lien-he",
               defaults: new { controller = "Page", action = "LienHe" }
           );
            routes.MapRoute(
              name: "Page.dang_ky",
              url: "dang-ky",
              defaults: new { controller = "Page", action = "DangKy" }
          );
            routes.MapRoute(
                name: "page.dang_nhap",
                url: "dang-nhap",
                defaults: new { controller = "Page", action = "DangNhap" }
            );
            routes.MapRoute(
              name: "Page.chinh_sach",
              url: "chinh-sach",
              defaults: new { controller = "Page", action = "ChinhSach" }
          );

            routes.MapRoute(
            name: "Account.dang_nhap",
            url: "dang-nhap",
            defaults: new { controller = "Account", action = "DangNhap" }
           );

            routes.MapRoute(
            name: "Account.dang_ky",
            url: "dang-ky",
            defaults: new { controller = "Account", action = "DangKy" }
        );

  

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Page", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
