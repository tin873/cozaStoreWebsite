using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cozaStore.Models
{
    [Table("Role")]
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int RoleID { get; set; }

        [StringLength(10)]
        [DisplayName("Tên quyền")]
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
