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
    [Table("Contact")]
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactID { get; set; }

        [DisplayName("Email")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Bạn cần nhập đúng định dạng mật khẩu")]
        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(50, ErrorMessage = "The Email must be between 12 and 50 characters", MinimumLength = 12)]
        public string Email { get; set; }

        [StringLength(500)]
        [DisplayName("Mô tả")]
        public string Description { get; set; }
    }
}
