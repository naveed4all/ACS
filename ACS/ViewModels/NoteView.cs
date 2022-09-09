using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class NoteView : CommonModel
    {
        public int NoteID { get; set; }
        public string NoteDescription { get; set; }
    }
}
