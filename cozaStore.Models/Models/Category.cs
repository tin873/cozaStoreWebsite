using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cozaStore.Models
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [DisplayName("Tên danh mục")]
        [Required(ErrorMessage = "Tên nhà cung cấp không được để trống")]
        [StringLength(50, ErrorMessage ="Tên danh mục phải có ít nhất 5 kí tự và nhiều nhất 30 kí tự", MinimumLength =5)]
        public string CategoryName { get; set; }

        [DisplayName("Mô tả")]
        [StringLength(500)]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
