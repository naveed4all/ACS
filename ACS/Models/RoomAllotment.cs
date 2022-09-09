using ACS.Models.Common_Model;
namespace ACS.Models
{
    public class RoomAllotment : CommonModel
    {
        public int RoomAllotmentID { get; set; }
        public int PartyID { get; set; }
        public string RoomNo { get; set; }
        public double MonthlyRent { get; set; }
        public DateTime StartDate { get; set; }

        public Party Party { get; set; }
    }
}
