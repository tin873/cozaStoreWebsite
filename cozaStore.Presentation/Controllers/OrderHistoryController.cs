using cozaStore.BusinessLogicLayer;
using cozaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Transactions;
using cozaStore.Common;

namespace cozaStore.Presentation.Controllers
{
    public class OrderHistoryController : Controller
    {
        private readonly IOrderServices _order;
        private readonly IUserServieces _user;
        private readonly IProductDetailServices _productDetail;
        public OrderHistoryController(IOrderServices order, IUserServieces user, IProductDetailServices productDetail)
        {
            _order = order;
            _user = user;
            _productDetail = productDetail;
        }
        // GET: OrderHistory
        public async Task<ActionResult> Index()
        {
            var user = await _user.GetByIdAsync(Session["UserId"]);
            var orders = user.Orders.ToList();
            return View(orders);
        }

        public async Task<ActionResult> OrderHistoryDetail(int id)
        {
            Order orders = await _order.GetByIdAsync(id);
            return View(orders);
        }
        /// <summary>
        /// the method cencell order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> CencellOrder(int id)
        {
            //update order
            Order orders = await _order.GetByIdAsync(id);
            orders.Status = Status.cancelled;
            await _order.UpdateAsync(orders);
            //update product quantity

            foreach (var orderDetail in orders.OrderDetails)
            {
                ProductDetail productDetail = await _productDetail.GetByIdAsync(orderDetail.ProductDetail.ProductDetailId);
                productDetail.Quantity += orderDetail.Quantity;
                await _productDetail.UpdateAsync(productDetail);
            }

            return View(orders);
        }
        /// <summary>
        /// the method is re-order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> OrderRealease(int id)
        {
            int dem = 0;
            Order orders = await _order.GetByIdAsync(id);
            List<CartItem> cart = Session[Constant.Cart] as List<CartItem> ?? new List<CartItem>();
            foreach (var orderDetail in orders.OrderDetails)
            {
                ProductDetail product = await _productDetail.GetByIdAsync(orderDetail.ProductDetail.ProductDetailId);
                if (product.Quantity >= 1)
                {
                    dem++;
                }    
            }
            if(dem == orders.OrderDetails.Count())
            {
                foreach (var orderDetail in orders.OrderDetails)
                {
                    var itemInCart = cart.FirstOrDefault(x => x.ProductDetail.ProductDetailId == orderDetail.ProductDetail.ProductDetailId);
                    if(itemInCart == null)
                    {
                        cart.Add(new CartItem()
                        {
                            ProductDetail = orderDetail.ProductDetail,
                            Quantity = 1,
                        });
                    } 
                }
                Session[Constant.Cart] = cart;
                return RedirectToAction("Index","ShoppingCart");
            }   
            else
            {
                return RedirectToAction("_ErrorOrder");
            }    
        }

        public PartialViewResult _ErrorOrder()
        {
            return PartialView();
        }
        /// <summary>
        /// all methods have display partial view of order history
        /// </summary>
        /// <returns></returns>
        public async Task<PartialViewResult> _WaitConfirm()
        {
            var user = await _user.GetByIdAsync(Session["UserId"]);
            var orders = user.Orders.Where(h => h.Status.ToString().Equals("waitForConfirm")).ToList();
            return PartialView(orders);
        }
        public async Task<PartialViewResult> _Cancelled()
        {
            var user = await _user.GetByIdAsync(Session["UserId"]);
            var orders = user.Orders.Where(h => h.Status.ToString().Equals("cancelled")).ToList();
            return PartialView(orders);
        }
        public async Task<PartialViewResult> _Deliverded()
        {
            var user = await _user.GetByIdAsync(Session["UserId"]);
            var orders = user.Orders.Where(h => h.Status.ToString().Equals("delivered")).ToList();
            return PartialView(orders);
        }
        public async Task<PartialViewResult> _Delivering()
        {
            var user = await _user.GetByIdAsync(Session["UserId"]);
            var orders = user.Orders.Where(h => h.Status.ToString().Equals("shipping")).ToList();
            return PartialView(orders);
        }
    }
}