using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using WebBanHang.EFF;

namespace WebBanHang.Controllers
{
    public class ApiController : System.Web.Mvc.Controller
    {
        // http://domain.com/api/products
        public System.Web.Mvc.ActionResult GetProducts()
        {
            dynamic lstProduct = null;

            // Lấy dữ liệu danh sách Sản phẩm
            // Entity Framework
            using (QuanLyBanHangEntities context = new QuanLyBanHangEntities())
            {
                lstProduct = (from p in context.products
                              select new
                              {
                                  p.id,
                                  p.product_code,
                                  p.product_name,
                                  p.standard_cost,
                                  p.list_price
                              }).ToList();
            }

            return Json(lstProduct, JsonRequestBehavior.AllowGet);

        }
        // POST : http//domain.com/api/products/{id}/delete
        [System.Web.Mvc.HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                using (QuanLyBanHangEntities context = new QuanLyBanHangEntities())
                {
                    products products = context.products.Find(id);
                    context.products.Remove(products);
                    context.SaveChanges();
                }

                object result = new
                {
                    Code = 200,
                    Message = "Đã xoá product thành công!"
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                object result = new
                {
                    Code = 500,
                    Message = "Đã có lỗi xảy ra" + ex.Message
                };
                return Json(result);


            }

        }
        // POST : http//domain.com/api/products/{id}/create
        [System.Web.Mvc.HttpPost]
        public ActionResult Create([FromBody]products product)
        {
            try
            {
                using (QuanLyBanHangEntities context = new QuanLyBanHangEntities())
                {
                
                    context.products.Add(product);
                    context.SaveChanges(); //id tự sinh
                }

                object result = new
                {
                    Code = 201,
                    Message = "Đã tạo product thành công!",
                    CreatedObject = product
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                object result = new
                {
                    Code = 500,
                    Message = "Đã có lỗi xảy ra" + ex.Message
                };
                return Json(result);


            }



        }

        // POST : http//domain.com/api/products/{id}/edit
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(int id, [FromBody]products product)
        {
            try
            {
                using (QuanLyBanHangEntities context = new QuanLyBanHangEntities())
                {
                    products productEdited = context.products.Find(id);
                    if (String.IsNullOrEmpty(product.product_code))
                    {
                        productEdited.product_code = product.product_code;
                    }
                    if (String.IsNullOrEmpty(product.product_name))
                    {
                        productEdited.product_name = product.product_name;
                    }
                    if (String.IsNullOrEmpty(product.product_name))
                    {
                        productEdited.description = product.description;
                    }
                    if (product.standard_cost > 0)
                    {
                        productEdited.standard_cost = product.standard_cost;
                    }
                    if (product.list_price > 0)
                    {
                        productEdited.list_price = product.list_price;
                    }
                    if (product.target_level > 0)
                    {
                        productEdited.target_level = product.target_level;
                    }
                    if (product.reorder_level > 0)
                    { 
                        productEdited.reorder_level = product.reorder_level;
                    }
                    if (product.minimum_reorder_quantity > 0)
                    {
                        productEdited.minimum_reorder_quantity = product.minimum_reorder_quantity;
                    }
                    if (String.IsNullOrEmpty(product.quantity_per_unit))
                    {
                        productEdited.quantity_per_unit = product.quantity_per_unit;
                    }
                    if (product.discontinued > 0)
                    {
                        productEdited.discontinued = product.discontinued;
                    }
                    if (String.IsNullOrEmpty(product.category))
                    {
                        productEdited.category = product.category;
                    }
                    if (String.IsNullOrEmpty(product.image))
                    {
                        productEdited.image = product.image;
                    }
                    
                    productEdited.order_details = product.order_details;
                 
                          
            
                    context.SaveChanges(); //id tự sinh
                }

                object result = new
                {
                    Code = 200,
                    Message = "Đã sửa product thành công!",
                    CreatedObject = product
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                object result = new
                {
                    Code = 500,
                    Message = "Đã có lỗi xảy ra" + ex.Message
                };
                return Json(result);


            }



        }



    }

}



   