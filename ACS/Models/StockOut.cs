using ACS.Models.Common_Model;
using ACS.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.Models
{
    public class StockOut 
    {
        [Key]
        public int StockOutID { get; set; }
         [ForeignKey("Invoice")]
        public int InvoiceID { get; set; }
        public int InventoryID { get; set; }
        public int ItemID { get; set; }
        public int Qty { get; set; }
        public double Amount { get; set; }
        public bool IsActive { get; set; }
        public Inventory Inventory { get; set; }
        public Item Item { get; set; }
        public Invoice Invoice { get; set; }


        //[ForeignKey("Party")]
        //public int ReceivedByPartyID { get; set; }
        //[ForeignKey("StockOutBill")]
        //public int StockOutBillID { get; set; }
        //public StockOutBill StockOutBill { get; set; }

    }
}
