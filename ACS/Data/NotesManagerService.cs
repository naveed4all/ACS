using ACS.Services;
using ACS.Services.Interfaces;
using ACS.ViewModels;


namespace ACS.Data
{
    public class NotesManagerService
    {

        private readonly INoteService _NoteService;
        
        public NotesManagerService(INoteService noteService)
        {
            _NoteService = noteService;
            
        }
        //Add-Note
        public async Task<NoteView> AddNote(NoteView noteView)
        {
            noteView.CreatedDateTime = DateTime.Now;
            noteView.CreatedByUserID = 1;
            noteView = await _NoteService.AddNote(noteView);




            return noteView;

        }
        //Get-All-Notes
        public List<NoteView> GetAll()
        {
            var noteView = _NoteService.GetAll();
            
            return noteView;
        }

        


        //Get-Notes-by-id
        public NoteView GetById(int id)
        {
            return _NoteService.GetById(id);
        }
        

        

        //Update-Notes
        public async Task<NoteView> UpdateNote(NoteView noteView)
        {
            noteView.UpdatedDateTime = DateTime.Now;
            noteView.UpdatedByUserID = 1;
            noteView = await _NoteService.UpdateNote(noteView);

            return noteView;

        }

        //Delete-Notes

        public async Task<bool> DeleteNote(int id)
        {
            return await _NoteService.DeleteNote(id);
        }


    }
}

