using ACS.Models;
using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class CategoryView : CommonModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public CategoryType Type { get; set; }
    }
}
