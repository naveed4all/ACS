using System.ComponentModel.DataAnnotations;
using ACS.Models.Common_Model;
using ACS.Models.User_Model;

namespace ACS.Models
{
    public class RolePermission : CommonModel
    {
        [Key]
        public int RolePermissionId { get; set; }
        public int PermissionId { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
