using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class PartyView : CommonModel
    {
        public int PartyID { get; set; }
        public string PartyName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
     
        public string? Email { get; set; }
    }
}
