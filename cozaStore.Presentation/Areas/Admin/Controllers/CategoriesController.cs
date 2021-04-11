using cozaStore.BusinessLogicLayer;
using cozaStore.Models;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace cozaStore.Presentation.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryServices _category;
        public CategoriesController(ICategoryServices category)
        {
            _category = category;
        }
        // GET: Admin/Categories
        public async Task<ActionResult> Index()
        {
            return View(await _category.GetAllAsync());
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CategoryID,CategoryName,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                await _category.CreateAsync(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await _category.GetByIdAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CategoryID,CategoryName,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                await _category.UpdateAsync(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await _category.GetByIdAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _category.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
