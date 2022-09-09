using System.ComponentModel.DataAnnotations;
using ACS.Models.Common_Model;

namespace ACS.Models
{ 
    public class Permission : CommonModel
    {
        [Key]
        public int PermissionId { get; set; }
        public string PermissionTitle { get; set; }
        public string PermissionSubTitle { get; set; }
    }
}
