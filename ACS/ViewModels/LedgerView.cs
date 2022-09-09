using ACS.Models;
using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class LedgerView : CommonModel
    {
        public int LedgerID { get; set; }
        public int InvoiceID { get; set; }
        //public string InvoiceNo { get; set; }
        public double Amount { get; set; }
        public string? Narration { get; set; }
        public DateTime Date { get; set; }

        //public Invoice Invoice { get; set; }
    }
}
