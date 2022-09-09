using System.ComponentModel.DataAnnotations;
using ACS.Models.Common_Model;


namespace ACS.Models
{
    public class Inventory : CommonModel
    {
        [Key]
        public int InventoryID { get; set; }
        public int PartyID { get; set; }
        public int SizeID { get; set; }
        public int ItemID { get; set; }
        public DateTime ReceivedDate { get; set; }
        public int GRNo { get; set; }
        public string MarkOn { get; set; }
        public string PMarka { get; set; }
        public string  CustomerName { get; set; }
        public int ArticleNo { get; set; }
        public int RoomNo { get; set; }
        public int RackNo { get; set; }
        public int StockInQty { get; set; }
        public int RemainingQty { get; set; }
        public double MonthlyRent { get; set; }
        public double Discount { get; set; } = 0;
        public int DiscountDays { get; set; } = 0;


        public Party Party { get; set; }
        public Size Size { get; set; }
        public Item Item { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<StockOut> StockOuts { get; set; }
        public ICollection<InventoryNote> InventoryNotes { get; set; }
        public ICollection<InventoryPartyLog> OwnerShipLogs { get; set; }
    }
}
