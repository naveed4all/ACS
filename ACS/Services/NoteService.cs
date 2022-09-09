using ACS.AppDBContext;
using ACS.Models;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;

namespace ACS.Services
{
    public class NoteService : INoteService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public NoteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NoteView> AddNote(NoteView noteView)
        {
            try
            {
                var note = _mapper.Map<Note>(noteView);
                note.IsActive = true;
                _context.Note.Add(note);
                await _context.SaveChangesAsync();
                return _mapper.Map<NoteView>(note);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Note", e);
            }
        }

        public async Task<bool> DeleteNote(int id)
        {
            var isDeleted = false;
            try
            {
                var note = _context.Note.FirstOrDefault(x => x.NoteID == id);
                //_context.Note.Remove(note);
                if (note.IsActive)
                {
                    note.IsActive = false;
                    _context.Note.Update(note);
                    await _context.SaveChangesAsync();
                }
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Note", e);
            }
            return isDeleted;
        }

        public List<NoteView> GetAll()
        {
            try
            {
                var notes = _context.Note.Where(x=>x.IsActive==true).ToList();
                return _mapper.Map<List<Note>, List<NoteView>>(notes);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Notes", e);
            }
        }

        public NoteView GetById(int id)
        {
            try
            {
                var note = _context.Note.FirstOrDefault(x => x.NoteID == id);
                return _mapper.Map<NoteView>(note);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Note By Id", e);
            }
        }

        public async Task<NoteView> UpdateNote(NoteView noteView)
        {
            try
            {
                _context.ChangeTracker.Clear();
                var note = _mapper.Map<Note>(noteView);
                _context.Note.Update(note);
                await _context.SaveChangesAsync();
                return _mapper.Map<NoteView>(note);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Note", e);
            }
        }
    }
}
