using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface INoteService
    {
        NoteView GetById(int id);
        List<NoteView> GetAll();
        Task<bool> DeleteNote(int id);
        Task<NoteView> AddNote(NoteView noteView);
        Task<NoteView> UpdateNote(NoteView noteView);
    }
}
