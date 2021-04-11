using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cozaStore.Models
{
    [Table("Coupon")]
    public class Coupon
    {
        [Key]
        [DisplayName("Mã giảm giá")]
        [StringLength(20)]
        public string CouponCode { get; set; }


        [Required]
        [DisplayName("Phần trăm giảm")]
        public int Discount { get; set; }

        [StringLength(500)]
        [DisplayName("Ghi chú")]
        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
