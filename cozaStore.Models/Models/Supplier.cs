using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cozaStore.Models
{
    [Table("Supplier")]
    public class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierID { get; set; }

        [DisplayName("Tên nhà cung cấp")]
        [Required(ErrorMessage = "Tên nhà cung cấp không được để trống")]
        [StringLength(50, MinimumLength = 5, ErrorMessage ="Tên nhà cung cấp phải có ít nhất 5 kí tự và nhiều nhất 50 kí tự.")]
        public string SupplierName { get; set; }

        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ nhà cung cấp không được để trống")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Địa chỉ nhà cung cấp phải có ít nhất 5 kí tự và nhiều nhất 50 kí tự.")]
        public string Address { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [StringLength(20)]
        public string Phone { get; set; }



        public virtual ICollection<Product> Products { get; set; }
    }
}
