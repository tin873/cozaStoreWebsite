using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cozaStore.DataAccessLayer;
using cozaStore.Models;
using cozaStore.BusinessLogicLayer;

namespace cozaStore.Presentation.Areas.Admin.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly IProductDetailServices _productDetail;
        private readonly IProductServices _product;
        public ProductDetailsController(IProductDetailServices productDetail, IProductServices product)
        {
            _productDetail = productDetail;
            _product = product;
        }

        // GET: Admin/ProductDetails
        public async Task<ActionResult> Index(int? id)
        {
            ViewBag.productId = id;
            var productDetails = await _productDetail.FindAllAsync(filter: x => x.Product.ProductID == id);
            return View(productDetails);
        }



        // GET: Admin/ProductDetails/Create
        [HttpGet]
        public ActionResult Create(int? id)
        {
            var product = _product.GetById(id);
            ViewBag.productId = id;
            ViewBag.productName = product.ProductName;
            ViewBag.price = product.Price;
            return View();
        }

        // POST: Admin/ProductDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductDetailId,ProductName,Image,Price,Size,Color,Quantity,ProductID")] ProductDetail productDetail)
        {
            try
            {
                productDetail.Image = "";
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/wwwroot/images/" + FileName);
                    f.SaveAs(UploadPath);
                    productDetail.Image = FileName;
                }
                await _productDetail.CreateAsync(productDetail);
                return RedirectToAction("Index", new { id = productDetail.Product.ProductID});
            }
            catch (Exception)
            {
                return View(productDetail);
            }
        }

        // GET: Admin/ProductDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetail productDetail = await _productDetail.GetByIdAsync(id);
            ViewBag.productId = productDetail.Product.ProductID;
            ViewBag.price = productDetail.Product.Price;
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            return View(productDetail);
        }

        // POST: Admin/ProductDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductDetailId,ProductName,Image,Price,Size,Color,Quantity,ProductID")] ProductDetail productDetail)
        {
            
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/wwwroot/images/" + FileName);
                    f.SaveAs(UploadPath);
                    productDetail.Image = FileName;
                }
                await _productDetail.UpdateAsync(productDetail);
                return RedirectToAction("Index", new { id = productDetail.ProductID});
          
           
        }

        // GET: Admin/ProductDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetail productDetail = await _productDetail.GetByIdAsync(id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            return View(productDetail);
        }

        // POST: Admin/ProductDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var product = _productDetail.GetById(id);
            int productId = product.Product.ProductID;
            await _productDetail.DeleteAsync(id);
            return RedirectToAction("Index", new { id= productId});
        }
    }
}
