using ACS.AppDBContext;
using ACS.Models;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;

namespace ACS.Services
{
    public class InventoryNoteService : IInventoryNoteService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public InventoryNoteService(AppDbContext context,IMapper mapper)
        {
                _context = context;
                _mapper = mapper;
        }

        public async Task<InventoryNoteView> AddInventoryNote(InventoryNoteView inventoryNoteView)
        {
            try
            {
                var inventoryNote = _mapper.Map<InventoryNote>(inventoryNoteView);
                
                _context.InventoryNote.Add(inventoryNote);
                await _context.SaveChangesAsync();
                return _mapper.Map<InventoryNoteView>(inventoryNote);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Inventory Note", e);
            }
        }

        public async Task<bool> DeleteInventoryNote(int id)
        {
            var isDeleted = false;
            try
            {
                var inventoryNote = _context.InventoryNote.FirstOrDefault(x => x.InventoryNoteID == id);
                _context.InventoryNote.Remove(inventoryNote);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Inventory Note", e);
            }
            return isDeleted;
        }

        public List<InventoryNoteView> GetAll(int id)
        {
            try
            {
                var inventoryNotes = _context.InventoryNote.ToList();
                return _mapper.Map<List<InventoryNote>, List<InventoryNoteView>>(inventoryNotes);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Inventory Notes", e);
            }
        }

        public InventoryNoteView GetById(int id)
        {
            try
            {
                var inventoryNote = _context.InventoryNote.FirstOrDefault(x => x.InventoryNoteID == id);
                return _mapper.Map<InventoryNoteView>(inventoryNote);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Inventory Note By Id", e);
            }
        }

        public async Task<InventoryNoteView> UpdateInventoryNote(InventoryNoteView inventoryNoteView)
        {
            try
            {
                var inventoryNote = _mapper.Map<InventoryNote>(inventoryNoteView);
                _context.InventoryNote.Update(inventoryNote);
                await _context.SaveChangesAsync();
                return _mapper.Map<InventoryNoteView>(inventoryNote);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Inventory Note", e);
            }
        }
    }
}
