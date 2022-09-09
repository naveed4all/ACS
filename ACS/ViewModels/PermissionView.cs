using ACS.Models;
using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class PermissionView : CommonModel
    {
        public int PermissionId { get; set; }
        public string PermissionTitle { get; set; }
        public string PermissionSubTitle { get; set; }
    }
}
