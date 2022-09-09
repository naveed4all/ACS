using ACS.Models.Common_Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACS.ViewModels
{
    public class StockOutBillView : CommonModel
    {
        public int StockOutBillID { get; set; }
        public int ReceivedByPartyID { get; set; }
        public double TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public string GivenBy { get; set; }

        //public PartyView Party { get; set; }
        public List<StockOutView> StockOutRecords { get; set; }
    }
}
