using cozaStore.DataAccessLayer;
using cozaStore.Models;
using System;
using System.Collections.Generic;
using System.Transactions;
namespace cozaStore.BusinessLogicLayer
{
    public class CheckOutServices : ICheckOutServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericReposistory<Order> _orderReposistory;
        private readonly IGenericReposistory<OrderDetail> _orderDetailReposistory;
        private readonly IGenericReposistory<ProductDetail> _productReposistory;

        public CheckOutServices(IUnitOfWork unitOfWork, IGenericReposistory<Order> orderReposistory, IGenericReposistory<OrderDetail> orderDetailReposistory, IGenericReposistory<ProductDetail> productReposistory)
        {
            _unitOfWork = unitOfWork;
            _orderReposistory = orderReposistory;
            _orderDetailReposistory = orderDetailReposistory;
            _productReposistory = productReposistory;
        }
        public void CheckOut(Order order, List<OrderDetail> orderDetails)
        {
            using(var transaction = new TransactionScope())
            {
                order.CreateDate = DateTime.Now;
                order.ShippedDate = DateTime.Now.AddDays(3);
                _orderReposistory.Add(order);
                foreach (var orderDetail in orderDetails)
                {
                    var productDetail = _productReposistory.GetById(orderDetail.ProductDetail.ProductDetailId);
                    productDetail.Quantity -= orderDetail.Quantity;
                    _productReposistory.Update(productDetail);
                    orderDetail.Order = order;
                    _orderDetailReposistory.Add(orderDetail);
                }
                _unitOfWork.Commit();
                transaction.Complete();
            }
        }
    }
}
