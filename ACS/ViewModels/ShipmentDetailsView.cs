using ACS.Models;
using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class ShipmentDetailsView : CommonModel
    {
        public int ShipmentDetailsID { get; set; }
        public string ShipmentNo { get; set; }
        public string Shipline { get; set; }
        public string VehicleNo { get; set; }
        public string Destination { get; set; }
        public double Amount { get; set; }
        public double AmountReceived { get; set; }
        public int PartyID { get; set; }
        //public string PartyName { get; set; }
        public DateTime Date { get; set; }

        public PartyView Party { get; set; }
    }
}
