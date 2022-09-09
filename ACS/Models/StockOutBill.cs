using ACS.Models.Common_Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.Models
{
    public class StockOutBill : CommonModel
    {
        [Key]
        public int StockOutBillID { get; set; }
        [ForeignKey("Party")]
        public int ReceivedByPartyID { get; set; }
        public double TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public string GivenBy { get; set; }

        public Party Party { get; set; }
        public List<StockOut> StockOutRecords { get; set; }
    }
}
