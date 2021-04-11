using cozaStore.BusinessLogicLayer;
using cozaStore.Common;
using cozaStore.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace cozaStore.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _category;
        private readonly IContactServices _contact;
        private readonly IUserServieces _user;
        private readonly IRoleServices _role;

        public HomeController(IProductServices productServices, ICategoryServices category, IContactServices contact, IUserServieces user, IRoleServices role)
        {
            _productServices = productServices;
            _category = category;
            _contact = contact;
            _user = user;
            _role = role;
        }
        public ActionResult Index()
        {
            var products = _productServices.GetTop(orderBy: x => x.OrderBy(p => p.ProductName));
            return View(products);
        }

        public PartialViewResult _TopProductNew()
        {
            var products = _productServices.GetTop(orderBy: x => x.OrderByDescending(p => p.ProductName));
            return PartialView(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Contact(FormCollection data)
        {
            var email = data["email"];
            var msg = data["msg"];
            var contact = new Contact()
            {
                Email = email,
                Description = msg
            };
            await _contact.CreateAsync(contact);
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(FormCollection data)
        {
            var email = data["email"];
            var password = data["pass"];
            var user = await _user.FindAsync(filter: x => x.Email.Equals(email) && x.PassWord.Equals(password));
            if (user != null)
            {
                if (user.Role.RoleID == 2)
                {
                    Session["fullName"] = user.FullName;
                    Session["address"] = user.Address;
                    Session["phone"] = user.Phone;
                    Session["email"] = user.Email;
                    Session["userId"] = user.UserID;
                    if(Session[Constant.Cart] != null)
                    {
                        return RedirectToAction("Index","ShoppingCart");
                    }   
                    else
                    {
                        return RedirectToAction("Index");
                    }    
                }
                else
                {
                    Session["fullNameAdmin"] = user.FullName;
                    Session["addressAdmin"] = user.Address;
                    Session["emailAdmin"] = user.Email;
                    Session["phoneAdmin"] = user.Phone;
                    Session["adminId"] = user.UserID;
                    return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
                }
            }
            else
            {
                ViewBag.error = "Sai tên đăng nhập hoặc mật khẩu!";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(FormCollection data)
        {
            var fullName = data["fullName"];
            var email = data["email"];
            var pass = data["pass"];
            var address = data["address"];
            var phone = data["phone"];
            var users = _user.Find(filter: x => x.Email.Equals(email));
            var users1 = _user.Find(filter: x => x.Phone.Equals(phone));
            var role = await _role.GetByIdAsync(2);
            if (users == null)
            {
                if(users1 == null)
                {
                    var user = new User()
                    {
                        FullName = fullName,
                        Email = email,
                        PassWord = pass,
                        Address = address,
                        Phone = phone,
                        Role = role
                    };
                    await _user.CreateAsync(user);
                    return RedirectToAction("Login");
                }    
                else
                {
                    ViewBag.error2 = "Số điện thoại này đã được đăng kí!";
                }    
            }
            else
            {
                ViewBag.error1 = "Email này đã tồn tại!";
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> InforUser()
        {
            var id = Session["userId"];
            var user = await _user.GetByIdAsync(id);
            return View(user);
        }
        [HttpPost]
        public async Task<ActionResult> InforUser(FormCollection data)
        {
            var id = Session["userId"];
            var fullName = data["fullName"];
            var email = data["email"];
            var pass = data["pass"];
            var address = data["address"];
            var phone = data["phone"];
            var user = new User()
            {
                UserID = int.Parse(id.ToString()),
                FullName = fullName,
                Email = email,
                PassWord = pass,
                Address = address,
                Phone = phone,
                RoleID = 2
            };
            if(user != null)
            {
                await _user.UpdateAsync(user);
                Session["fullName"] = user.FullName;
                Session["address"] = user.Address;
                Session["phone"] = user.Phone;
                Session["email"] = user.Email;
                return RedirectToAction("Index");
            }    
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        public PartialViewResult _Footer()
        {
            var categories = _category.GetAll();
            return PartialView(categories);
        }
    }
}