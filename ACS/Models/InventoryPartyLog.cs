using System.ComponentModel.DataAnnotations;

namespace ACS.Models
{
    public class InventoryPartyLog
    {
        [Key]
        public int LogId { get; set; }
        public int PartyID { get; set; }
        public int InventoryID { get; set; }
        public int GRNo { get; set; }
        public DateTime OwnerShipEndDate { get; set; }
        public Party Party { get; set; }
        public Inventory Inventory { get; set; }
    }
}
