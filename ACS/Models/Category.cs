using ACS.Models.Common_Model;
using System.ComponentModel.DataAnnotations;

namespace ACS.Models
{
    public class Category : CommonModel
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public CategoryType Type { get; set; }

    }
    public enum CategoryType
    {
        Expense,
        Income
    }
}
