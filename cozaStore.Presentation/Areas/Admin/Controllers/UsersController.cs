using cozaStore.BusinessLogicLayer;
using cozaStore.Models;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace cozaStore.Presentation.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserServieces _user;
        public UsersController(IUserServieces user)
        {
            _user = user;
        }
        // GET: Admin/Users
        public async Task<ActionResult> Index()
        {
            var users = await _user.GetAllAsync();
            return View(users.ToList());
        }
        // GET: Admin/Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await _user.GetByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _user.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
