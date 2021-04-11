using cozaStore.BusinessLogicLayer;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace cozaStore.Presentation.Areas.Admin.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactServices _contact;
        public ContactsController(IContactServices contact)
        {
            _contact = contact;
        }

        // GET: Admin/Contacts
        public async Task<ActionResult> Index()
        {
            return View(await _contact.GetAllAsync());
        }

    }
}
