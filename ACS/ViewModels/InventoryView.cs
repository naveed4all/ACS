using ACS.Models;
using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class InventoryView : CommonModel
    {
        public int InventoryID { get; set; }
        public int PartyID { get; set; }
        public int SizeID { get; set; }
        public int ItemID { get; set; }
        public DateTime ReceivedDate { get; set; }
        public int GRNo { get; set; }
        public string MarkOn { get; set; }
        public string PMarka { get; set; }
        public string CustomerName { get; set; }
        public int ArticleNo { get; set; }
        public int RoomNo { get; set; }
        public int RackNo { get; set; }
        public int StockInQty { get; set; }
        public int RemainingQty { get; set; }
        public double MonthlyRent { get; set; }
        public double Discount { get; set; } = 0;
        public int DiscountDays { get; set; } = 0;

        public PartyView Party { get; set; }
        //public Size Size { get; set; }
        public ItemView Item { get; set; }
    }
}
