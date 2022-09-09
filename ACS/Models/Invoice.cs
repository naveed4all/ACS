using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ACS.Models.Common_Model;

namespace ACS.Models
{
    public class Invoice : CommonModel
    {
        [Key]
        public int InvoiceID { get; set; }
        public double TotalAmount { get; set; }
        public double AmountPaid { get; set; }
        public bool IsPaid { get; set; }
        public string ReceivedByName { get; set; }
        public string? Narration { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Party")]
        public int ReceivedByPartyID { get; set; }

        public Party Party { get; set; }
        public List<StockOut> StockOutRecords { get; set; }

    }
}
