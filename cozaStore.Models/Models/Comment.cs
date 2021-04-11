using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cozaStore.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }

        [DisplayName("Tên người Comment")]
        [Required(ErrorMessage = "Tên người comment không được để trống")]
        [StringLength(50, ErrorMessage = "tên người dùng phải có ít nhất 5 kí tự và nhiều nhất 50 kí tự", MinimumLength = 5)]
        public string NameUser { get; set; }

        [DisplayName("Email")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Bạn cần nhập đúng định dạng mật khẩu")]
        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(50, ErrorMessage = "The Email must be between 12 and 50 characters", MinimumLength = 12)]
        public string Email { get; set; }

        [DisplayName("Nội dung bình luận")]
        [Required(ErrorMessage = "Không được để trống nội dung bình luận")]
        [StringLength(500, ErrorMessage = "The comment must be between 5 and 500 characters", MinimumLength = 5)]
        public string Content { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}
