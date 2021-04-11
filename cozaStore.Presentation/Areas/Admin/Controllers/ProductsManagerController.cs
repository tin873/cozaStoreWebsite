using cozaStore.BusinessLogicLayer;
using cozaStore.Models;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace cozaStore.Presentation.Areas.Admin.Controllers
{
    public class ProductsManagerController : Controller
    {
        private readonly IProductServices _product;
        private readonly ICategoryServices _category;
        private readonly ISupplierServices _supplier;
        public ProductsManagerController(IProductServices product, ICategoryServices category, ISupplierServices supplier)
        {
            _product = product;
            _category = category;
            _supplier = supplier;
        }

        // GET: Admin/Products
        public async Task<ActionResult> Index()
        {
            var products = await _product.GetAllAsync();
            return View(products);
        }


        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(_category.GetAll(), "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(_supplier.GetAll(), "SupplierID", "SupplierName");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductID,ProductName,Image,Description,Price,SupplierID,CategoryID")] Product product)
        {

            try
            {
                product.Image = "";
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/wwwroot/images/" + FileName);
                    f.SaveAs(UploadPath);
                    product.Image = FileName;
                }
                await _product.CreateAsync(product);
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {

                ViewBag.CategoryID = new SelectList(_category.GetAll(), "CategoryID", "CategoryName", product.CategoryID);
                ViewBag.SupplierID = new SelectList(_supplier.GetAll(), "SupplierID", "SupplierName", product.SupplierID);
                return View(product);
            }
        }

        // GET: Admin/Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await _product.GetByIdAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(_category.GetAll(), "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(_supplier.GetAll(), "SupplierID", "SupplierName", product.SupplierID);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductID,ProductName,Image,Description,Price,SupplierID,CategoryID")] Product product)
        {
            try
            {
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/wwwroot/images/" + FileName);
                    f.SaveAs(UploadPath);
                    product.Image = FileName;
                }
                await _product.UpdateAsync(product);
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {

                ViewBag.CategoryID = new SelectList(_category.GetAll(), "CategoryID", "CategoryName", product.CategoryID);
                ViewBag.SupplierID = new SelectList(_supplier.GetAll(), "SupplierID", "SupplierName", product.SupplierID);
                return View(product);
            }

        }

        // GET: Admin/Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await _product.GetByIdAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _product.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
