using ACS.Models;
using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class StockOutView : CommonModel
    {
        public int StockOutID { get; set; }
        public int InvoiceID { get; set; }
        public int InventoryID { get; set; }
        public int ItemID { get; set; }
        public int Qty { get; set; }
        public double Amount { get; set; }
        public bool IsActive { get; set; }
        public InventoryView Inventory { get; set; }
        public ItemView Item { get; set; }
        public InvoiceView Invoice { get; set; }

        //
        public int GRNo{ get; set; }
        public string? ItemName{ get; set; }

        
    }
}
