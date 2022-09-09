using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class RolePermDTOView : CommonModel
    {       
        public int RoleId { get; set; }

        public int[] PermissionsID { get; set; }
    }
}
