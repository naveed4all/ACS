using ACS.Models.Common_Model;
using System.ComponentModel.DataAnnotations;

namespace ACS.Models
{
    public class ShipmentDetails : CommonModel
    {
        [Key]
        public int ShipmentDetailsID { get; set; }
        public string ShipmentNo { get; set; }
        public string Shipline { get; set; }
        public string VehicleNo { get; set; }
        public string Destination { get; set; }
        public double Amount { get; set; }
        public double AmountReceived { get; set; }
        public int PartyID { get; set; }       
        public DateTime Date { get; set; }

        public Party Party { get; set; }
    }
}
