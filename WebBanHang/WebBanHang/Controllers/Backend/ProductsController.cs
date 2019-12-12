using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.EFF;

namespace WebBanHang.Controllers.Backend
{
    public class ProductsController : Controller
    {
        private QuanLyBanHangEntities db = new QuanLyBanHangEntities();

        // GET: Products
        public ActionResult Index()
        {
            return View("~/Views/Backend/Products/Index.cshtml", db.products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products products = db.products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
       
        public ActionResult Create()
        {
            return View("~/Views/Backend/Products/Create.cshtml");
        }
        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,product_code,product_name,description,standard_cost,list_price,target_level,reorder_level,minimum_reorder_quantity,quantity_per_unit," +
            "discontinued,category,image")] products products, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                // Xử lý file : lưu file vào thư mục uploadedfile/productimages
                string _FileName = "";
                //Di chuyen file vao thu muc mong muon
                if (image.ContentLength > 0)
                {
                    _FileName = Path.GetFileName(image.FileName);
                    string _FileNameExtension = Path.GetExtension(image.FileName);
                    if ((_FileNameExtension == ".png"
                        || _FileNameExtension == ".jpg"
                        || _FileNameExtension == ".jpeg") == false)
                    {
                        return View(String.Format("File có đuôi {0} không hợp lệ. Vui lòng kiểm tra lại", _FileNameExtension));
                    }



                    string uploadedFolderPath = Server.MapPath("~/UploadedFiles/ProductImages"); //UploadedFiles/201911122018/ten file uploaed
                    if (Directory.Exists(uploadedFolderPath) == false)// Nếu thư mục cần lưu trữ file upload không tồn tại ( chưa có ) => tạo mới
                    {
                        Directory.CreateDirectory(uploadedFolderPath);
                    }

                    string _path = Path.Combine(uploadedFolderPath, _FileName);
                    image.SaveAs(_path);
                }

                    //Luu du lieu
                    products.image = image.FileName;
                    db.products.Add(products);
                    db.SaveChanges();
                    return RedirectToAction("Index");
              }

                return View(products);
            }

        
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products products = db.products.Find(id); // SELECT * From products WHERE ID
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product = products;
            return View("~/Views/Backend/Products/Edit.cshtml", products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,product_code,product_name,description,standard_cost,list_price," +
            "target_level,reorder_level,minimum_reorder_quantity,quantity_per_unit,discontinued,category,image")] products products, string image_oldFile, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)

            {

                string uploadedFolderPath = Server.MapPath("~/UploadedFiles/ProductImages");
                if (image == null) // Nếu không cập nhật file (không chọn file)
                {
                    //Giữ Nguyên giá trị của tên file trong cột 'image'
                    products.image = image_oldFile;
                }
                else // User chon file moi
                {
                    //1. Xoa file ảnh cũ để tránh rác
                    //~/UploadedFiles/ProductImage/img -> duong dan file anh cu
                    string filePathAnhCu = Path.Combine(uploadedFolderPath, (products.image == null ? "" : products.image));
                    if (System.IO.File.Exists(filePathAnhCu))
                    {
                        System.IO.File.Delete(filePathAnhCu);
                    }
                    //2. Uploaded file anh moi
                    // Xử lý file : lưu file vào thư mục uploadedfile/productimages
                    string _FileName = "";
                    //Di chuyen file vao thu muc mong muon
                    if (image != null && image.ContentLength > 0)
                    {
                        _FileName = Path.GetFileName(image.FileName);
                        string _FileNameExtension = Path.GetExtension(image.FileName);
                        if ((_FileNameExtension == ".png"
                            || _FileNameExtension == ".jpg"
                            || _FileNameExtension == ".jpeg") == false)
                        {
                            return View(String.Format("File có đuôi {0} không hợp lệ. Vui lòng kiểm tra lại", _FileNameExtension));
                        }




                        if (Directory.Exists(uploadedFolderPath) == false)// Nếu thư mục cần lưu trữ file upload không tồn tại ( chưa có ) => tạo mới
                        {
                            Directory.CreateDirectory(uploadedFolderPath);
                        }

                        string _path = Path.Combine(uploadedFolderPath, _FileName);
                        image.SaveAs(_path);

                    }
                    // Luu ten file vao database
                    products.image = _FileName;
                }
              

            
                    /* Update products
                    SET product_code = 'P333'
                    product_name = 'DELL 3333'
                    Where id = 604
                    */
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product = products;
            return View("~/Views/Backend/Products/Edit.cshtml", products);
        }

        // GET: Products/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products products = db.products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product = products;
            return View("~/Views/Backend/Products/Delete.cshtml", products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            products products = db.products.Find(id);
            db.products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
