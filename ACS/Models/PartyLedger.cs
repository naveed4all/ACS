using ACS.Models.Common_Model;
using System.ComponentModel.DataAnnotations;
namespace ACS.Models
{
    public class PartyLedger : CommonModel
    {
        [Key]
        public int PartyLedgerID { get; set; }
        public int PartyID { get; set; }
        public double ClosingBalance { get; set; }
        public double TodayDebit { get; set; }
        public double TodayCredit { get; set; }

        public Party Party { get; set; }
    }
}
