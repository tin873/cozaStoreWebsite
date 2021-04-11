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
    public class CouponsController : Controller
    {
        private readonly ICouponServices _coupon;
        public CouponsController(ICouponServices coupon) 
        {
            _coupon = coupon;
        }

        // GET: Admin/Coupons
        public async Task<ActionResult> Index()
        {
            return View(await _coupon.GetAllAsync());
        }


        // GET: Admin/Coupons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Coupons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CouponCode,Discount,Description")] Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                await _coupon.CreateAsync(coupon);
                return RedirectToAction("Index");
            }

            return View(coupon);
        }

        // GET: Admin/Coupons/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupon coupon = await _coupon.GetByIdAsync(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }
            return View(coupon);
        }

        // POST: Admin/Coupons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CouponCode,Discount,Description")] Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                await _coupon.UpdateAsync(coupon);
                return RedirectToAction("Index");
            }
            return View(coupon);
        }

        // GET: Admin/Coupons/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupon coupon = await _coupon.GetByIdAsync(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }
            return View(coupon);
        }

        // POST: Admin/Coupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _coupon.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
