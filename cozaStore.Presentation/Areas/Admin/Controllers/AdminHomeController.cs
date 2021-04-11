using cozaStore.BusinessLogicLayer;
using cozaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace cozaStore.Presentation.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        private readonly IUserServieces _user;
        private readonly IRoleServices _role;
        public AdminHomeController(IUserServieces user, IRoleServices role) 
        {
            _user = user;
            _role = role;
        }
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            if (Session["fullNameAdmin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home", new { Area = "" });
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home", new { area = "" });
        }

        [HttpGet]
        public async Task<ActionResult> EditProfile()
        {
            var user = await _user.GetByIdAsync(Session["adminId"]);
            var roles = await _role.GetAllAsync();
            ViewBag.RoleIds = new SelectList(roles, "RoleID", "RoleName");
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditProfile([Bind(Include = "UserID,FullName,Email,PassWord,Address,Phone,RoleID")] User user)
        {
            if(ModelState.IsValid)
            {
                await _user.UpdateAsync(user);
                Session["fullNameAdmin"] = user.FullName;
                return RedirectToAction("Index");
            }
            var roles = await _role.GetAllAsync();
            ViewBag.RoleIds = new SelectList(roles, "RoleID", "RoleName");
            return View(user);
        }
    }
}