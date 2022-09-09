using ACS.Models;
using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class PartyLedgerView : CommonModel
    {
        public int PartyLedgerID { get; set; }
        public int PartyID { get; set; }
        public double ClosingBalance { get; set; }
        public double TodayDebit { get; set; }
        public double TodayCredit { get; set; }

        //public Party Party { get; set; }
    }
}
