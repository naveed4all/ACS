using ACS.Models.Common_Model;
using System.ComponentModel.DataAnnotations;

namespace ACS.Models
{
    public class Party : CommonModel
    {
        [Key]
        public int PartyID { get; set; }
        public string PartyName { get; set; }
        public string Address { get; set; }        
        public string Contact { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<PartyLedger> PartyLedgers { get; set; }
        public ICollection<StockOut> StockOuts { get; set; }
        public ICollection<ShipmentDetails> ShipmentDetails { get; set; }
        public ICollection<RoomAllotment> RoomAllotments { get; set; }
        public ICollection<InventoryPartyLog> OwnerShipLogs { get; set; }

    }
}
