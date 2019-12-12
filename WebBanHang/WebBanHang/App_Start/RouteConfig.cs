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
                name: "Page.dang_nhap",
                url: "dang-nhap",
                defaults: new { controller = "Page", action = "DangNhap" }
            );

            routes.MapRoute(
             name: "product.chitiet",
             url: "sanpham-chitiet",
             defaults: new { controller = "Product", action = "ProductDetail" }
         );


            routes.MapRoute(
              name: "Page.chinh_sach",
              url: "chinh-sach",
              defaults: new { controller = "Page", action = "ChinhSach" }
          );

            //Route cho backend
            routes.MapRoute(
              name: "admin.page.dashboard",
              url: "admin/dashboard",
              defaults: new { controller = "Dashboard", action = "Index" },
              namespaces : new string[] {"WebBanHang.Controllers.Backend"}
          );

            //Route trang san pham
            routes.MapRoute(
              name: "admin.products.index",
              url: "admin/products",
              defaults: new { controller = "Products", action = "Index" },
              namespaces: new string[] { "WebBanHang.Controllers.Backend" }
          );

            //Route trang them moi san pham
            // URL admin/produts/create
            routes.MapRoute(
              name: "admin.products.create",
              url: "admin/products/create",
              defaults: new { controller = "Products", action = "Create" },
              namespaces: new string[] { "WebBanHang.Controllers.Backend" }
          );
            //Route trang Sua san pham
            // URL admin/produts/edit/{id}
            routes.MapRoute(
             name: "admin.products.edit",
             url: "admin/products/edit/{id}",
             defaults: new { controller = "Products", action = "Edit"},
             namespaces: new string[] { "WebBanHang.Controllers.Backend" }
         );


            //Route trang Xoa San Pham
            // URL admin/produts/delete/{id}
            routes.MapRoute(
             name: "admin.products.delete",
             url: "admin/products/delete/{id}",
             defaults: new { controller = "Products", action = "Delete" },
             namespaces: new string[] { "WebBanHang.Controllers.Backend" }
         );

            // Route dành cho API
            // route api lấy danh sách sản phẩm
            // URL: /api/products
            routes.MapRoute(
                name: "api.products",
                url: "api/products",
                defaults: new { controller = "Api", action = "GetProducts" }
            );

            // Route dành cho API
            // route api xoá sản phẩm
            // URL: /api/products/{id}/delete
            routes.MapRoute(
                name: "api.products.delete",
                url: "api/products/{id}/delete",
                defaults: new { controller = "Api", action = "Delete" , id = UrlParameter.Optional}
            );


            // Route dành cho API
            // route api Thêm sản phẩm
            // URL: /api/products/create
            routes.MapRoute(
                name: "api.products.create",
                url: "api/products/create",
                defaults: new { controller = "Api", action = "Create" }
            );


            // Route dành cho API
            // route api sửa sản phẩm
            // URL: /api/products/{id}/edit
            routes.MapRoute(
                name: "api.products.edit",
                url: "api/products/{id}/edit",
                defaults: new { controller = "Api", action = "Edit", id = UrlParameter.Optional }
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
