using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cozaStore.Models
{
    [Table("ProductsDetails")]
    public class ProductsDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductDetailID { get; set; }
        [DisplayName("Kích cỡ")]
        [StringLength(15)]
        public string Size { get; set; }

        [DisplayName("Mầu sắc")]
        [StringLength(50)]
        public string Color { get; set; }

        [Required(ErrorMessage = "Số lượng sản phẩm không được để trống!")]
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}
