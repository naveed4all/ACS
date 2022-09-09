using ACS.Models.Common_Model;

namespace ACS.Models
{
    public class Note : CommonModel
    {
        public int NoteID { get; set; }
        public string NoteDescription { get; set; }

        public ICollection<InventoryNote> InventoryNotes { get; set; }

    }
}
