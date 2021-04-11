using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cozaStore.Models
{
    [Table("User")]
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [DisplayName("Họ tên")]
        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Tên người dùng phải có ít nhất 5 kí tự và nhiều nhất 50 kí tự.")]
        public string FullName { get; set; }

        [DisplayName("Email")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Bạn cần nhập đúng định dạng email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Email phải có ít nhất 12 kí tự và nhiều nhất 50 kí tự.")]
        public string Email { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(30)]
        public string PassWord { get; set; }

        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Tên người dùng phải có ít nhất 5 kí tự và nhiều nhất 50 kí tự.")]
        public string Address { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [StringLength(20)]
        public string Phone { get; set; }

        [DefaultValue(2)]
        public int? RoleID { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual Role Role { get; set; }
    }
}
