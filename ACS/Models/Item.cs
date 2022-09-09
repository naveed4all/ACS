using ACS.Models.Common_Model;
using System.ComponentModel.DataAnnotations;

namespace ACS.Models
{
    public class Item : CommonModel
    {
        [Key]
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string? Description { get; set; }

        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<StockOut> StockOuts { get; set; }
    }
}
