using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cozaStore.Models
{
    [Table("Order")]
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [DisplayName("Ngày Đặt hàng")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Ngày gửi")]
        public DateTime ShippedDate { get; set; }



        [DisplayName("Họ tên")]
        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(30)]
        public string FullName { get; set; }

        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(50)]
        public string Address { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        [StringLength(20)]
        public string Phone { get; set; }

        [DisplayName("Ghi chú")]
        [StringLength(500)]
        public string Description { get; set; }

        public decimal SumTotal
        {
            get
            {
                decimal sumTotal = 0m;
                foreach (var item in OrderDetails)
                {
                    sumTotal = item.ProductDetail.Price * item.Quantity;
                }
                if (Coupon != null)
                {
                    sumTotal -= (Coupon.Discount * sumTotal) / 100;
                    return sumTotal;
                }
                else
                {
                    return sumTotal;
                }

            }
        }

        public decimal SumTotalNoDiscout
        {
            get
            {
                decimal sumTotal = 0m;
                foreach (var item in OrderDetails)
                {
                    sumTotal = item.ProductDetail.Price * item.Quantity;
                }
                return sumTotal;
            }
        }
        public Status Status { get; set; }

        public int UserId { get; set; }

        public string CouponCode { get; set; }

        public virtual Coupon Coupon { get; set; }


        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
