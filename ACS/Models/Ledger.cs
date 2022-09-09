using ACS.Models.Common_Model;
using System.ComponentModel.DataAnnotations;

namespace ACS.Models
{
    public class Ledger : CommonModel
    {
        [Key]
        public int LedgerID { get; set; }        
        public int InvoiceID { get; set; }
        public double Amount { get; set; }
        public string? Narration { get; set; }
        public DateTime Date { get; set; }

        //public Invoice Invoice { get; set; }

    }
}
