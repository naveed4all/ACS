using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class ItemView : CommonModel
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string? Description { get; set; }
    }
}
