using cozaStore.BusinessLogicLayer;
using cozaStore.Models;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace cozaStore.Presentation.Areas.Admin.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierServices _supplier;
        public SuppliersController(ISupplierServices supplier)
        {
            _supplier = supplier;
        }

        // GET: Admin/Suppliers
        public async Task<ActionResult> Index()
        {
            return View(await _supplier.GetAllAsync());
        }


        // GET: Admin/Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SupplierID,SupplierName,Address,Phone")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                await _supplier.CreateAsync(supplier);
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Admin/Suppliers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = await _supplier.GetByIdAsync(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Admin/Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SupplierID,SupplierName,Address,Phone")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                await _supplier.UpdateAsync(supplier);
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Admin/Suppliers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = await _supplier.GetByIdAsync(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Admin/Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _supplier.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
