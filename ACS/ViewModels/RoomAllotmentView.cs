using ACS.Models;
using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class RoomAllotmentView : CommonModel
    {
        public int RoomAllotmentID { get; set; }
        public int PartyID { get; set; }
        public string RoomNo { get; set; }
        public double MonthlyRent { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow.AddHours(5);

        //public string PartyName { get; set; }

        public PartyView Party { get; set; }
    }
}
