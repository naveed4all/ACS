using ACS.Models;
using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class RolePermissionView : CommonModel
    {
        public int RolePermissionId { get; set; }
        public int PermissionId { get; set; }
        public int RoleId { get; set; }

       
    }
}
