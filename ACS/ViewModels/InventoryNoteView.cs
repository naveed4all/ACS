using ACS.Models;

namespace ACS.ViewModels
{
    public class InventoryNoteView
    {
        public int InventoryNoteID { get; set; }

        public int InventoryID { get; set; }
        public int NoteID { get; set; }

        //public Inventory Inventory { get; set; }
        //public Note Note { get; set; }
    }
}
