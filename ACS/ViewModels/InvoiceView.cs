using ACS.Models;
using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class InvoiceView : CommonModel
    {
        public int InvoiceID { get; set; }
        public double TotalAmount { get; set; }
        public double AmountPaid { get; set; }
        public bool IsPaid { get; set; }
        public string ReceivedByName { get; set; }
        public string? Narration { get; set; }
        public DateTime Date { get; set; }        
        public int ReceivedByPartyID { get; set; }
        public PartyView Party { get; set; }
        public List<StockOutView> StockOutRecords { get; set; }      
    }
}
