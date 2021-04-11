using cozaStore.BusinessLogicLayer;
using cozaStore.Common;
using cozaStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace cozaStore.Presentation.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductServices _product;
        private readonly IProductDetailServices _productDetail;
        public ShoppingCartController(IProductServices product, IProductDetailServices productDetail)
        {
            _product = product;
            _productDetail = productDetail;
        }
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = Session[Constant.Cart];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            decimal total = 0m;
            foreach (var item in list)
            {
                total += item.Total;
            }
            ViewBag.GrandTotal = total;
            return View(list);
        }

        public async Task<ActionResult> GetIdProductDetail(string id)
        {
            var arr = id.Split(' ');
            int productId = int.Parse(arr[0]);
            string color = arr[1];
            string size = arr[2];
            int qty = int.Parse(arr[3]);
            Product product = await _product.GetByIdAsync(productId);
            ProductDetail productDetail = product.ProductDetails.Where(x => x.Color.ToUpper().Contains(color.ToUpper()) && x.Size.ToUpper().Contains(size.ToUpper())).FirstOrDefault();
            if(productDetail != null)
            {
                int id1 = productDetail.ProductDetailId;
                return RedirectToAction("AddToCart", new { id = id1 + " " + qty });
            }    
            else
            {
                return RedirectToAction("_ErrorOrderNull");
            }    
        }
        public PartialViewResult _ErrorOrderNull()
        {
            ViewBag.message = "Sản phẩm không tồn tại hoặc đã hết hàng!";
            return PartialView();
        }
        public PartialViewResult _ErrorOrder(string idQty)
        {
            //check quantity prooduct
            if (idQty != null)
            {
                var arr = idQty.Split(' ');
                int ProductDetailId = int.Parse(arr[0]);
                int qty = int.Parse(arr[1]);
                ProductDetail productDetail = _productDetail.GetById(ProductDetailId);
                if (arr.Length > 2)
                {
                    int qtyItem = int.Parse(arr[2]);
                    if ((productDetail.Quantity - qty - qtyItem) < 0)
                    {
                        ViewBag.message = "Hiện chỉ còn " + (productDetail.Quantity - qtyItem) + " sản phẩm!";
                    }
                }
                else
                {
                    if (productDetail.Quantity == 0)
                    {
                        ViewBag.message = "Sản phẩm hiện đã hết hàng vui lòng chọn sản phẩm khác!";
                    }
                    else
                    {
                        if (productDetail.Quantity <= qty)
                        {
                            if ((productDetail.Quantity - qty) >= 0)
                            {
                                ViewBag.message = "Hiện chỉ còn " + (productDetail.Quantity - qty) + " sản phẩm!";
                            }
                            else
                            {
                                ViewBag.message = "Hiện chỉ còn " + (productDetail.Quantity) + " sản phẩm!";
                            }
                        }

                    }
                }
            }
            return PartialView();
        }
        public async Task<ActionResult> AddToCart(string id)
        {
            var arr = id.Split(' ');
            int id1 = int.Parse(arr[0]);
            int qty = int.Parse(arr[1]);
            List<CartItem> cart = Session[Constant.Cart] as List<CartItem> ?? new List<CartItem>();

            CartItem model = new CartItem();

            ProductDetail product = await _productDetail.GetByIdAsync(id1);

            var itemInCart = cart.FirstOrDefault(x => x.ProductDetail.ProductDetailId == id1);

            if (itemInCart == null)
            {
                if (product.Quantity >= qty)
                {
                    cart.Add(new CartItem()
                    {
                        ProductDetail = product,
                        Quantity = qty,
                    });
                }
                else
                {
                    return RedirectToAction("_ErrorOrder", new { idQty = id1 + " " + qty });
                }
            }
            else
            {
                if ((itemInCart.Quantity + qty) <= product.Quantity)
                {
                    itemInCart.Quantity += qty;
                }
                else
                {
                    return RedirectToAction("_ErrorOrder", new { idQty = id1 + " " + qty + " " + itemInCart.Quantity });
                }
            }

            int qty1 = 0;
            foreach (var item in cart)
            {
                qty1 += item.Quantity;
            }
            model.Quantity = qty1;
            Session[Constant.Cart] = cart;

            return RedirectToAction("CartPartial");
        }
        public ActionResult CartPartial()
        {
            CartItem model = new CartItem();

            int qty = 0;
            if (Session[Constant.Cart] != null)
            {
                var list = (List<CartItem>)Session[Constant.Cart];
                foreach (var item in list)
                {
                    qty += item.Quantity;
                }
                model.Quantity = qty;
            }
            else
            {
                model.Quantity = 0;
            }

            return PartialView(model);
        }

        public JsonResult IncrementProduct(int productId)
        {
            List<CartItem> cart = Session[Constant.Cart] as List<CartItem>;

            ProductDetail productDetail = _productDetail.GetById(productId);

            CartItem item = cart.FirstOrDefault(x => x.ProductDetail.ProductDetailId == productId);

            if (productDetail.Quantity > item.Quantity+1)
            {
                item.Quantity++;
                var result = new { qty = item.Quantity, price = item.ProductDetail.Price };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if(productDetail.Quantity == item.Quantity + 1)
                {
                    item.Quantity++;
                    var result = new { qty = item.Quantity, price = item.ProductDetail.Price, qtyReal = productDetail.Quantity };

                    return Json(result, JsonRequestBehavior.AllowGet);
                }    
                else
                {
                    var result = new { qty = 0, price = 0 };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }    
            }
        }
        public PartialViewResult _ErrorQuantity(int id)
        {
            ProductDetail productDetail = _productDetail.GetById(id);
            ViewBag.errorQtity = "Hiện chỉ còn " + productDetail.Quantity + " sản phẩm!";
            return PartialView();
        }
        public ActionResult DecrementProduct(int productId)
        {
            List<CartItem> cart = Session[Constant.Cart] as List<CartItem>;

            CartItem item = cart.FirstOrDefault(x => x.ProductDetail.ProductDetailId == productId);

            if (item.Quantity > 1)
            {
                item.Quantity--;
            }
            else
            {
                item.Quantity = 0;
                cart.Remove(item);
            }

            var result = new { qty = item.Quantity, price = item.ProductDetail.Price };

            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public void RemoveProduct(int productId)
        {
            List<CartItem> cart = Session[Constant.Cart] as List<CartItem>;

            CartItem item = cart.FirstOrDefault(x => x.ProductDetail.ProductDetailId == productId);

            cart.Remove(item);

        }
        public PartialViewResult CartMini()
        {
            var cart = Session[Constant.Cart];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            decimal total = 0m;
            foreach (var item in list)
            {
                total += item.Total;
            }
            ViewBag.SumTotal = total;
            return PartialView(list);
        }

    }
}