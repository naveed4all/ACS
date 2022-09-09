using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface IInventoryNoteService
    {
        InventoryNoteView GetById(int id);
        List<InventoryNoteView> GetAll(int id);
        Task<bool> DeleteInventoryNote(int id);
        Task<InventoryNoteView> AddInventoryNote(InventoryNoteView inventoryNoteView);
        Task<InventoryNoteView> UpdateInventoryNote(InventoryNoteView inventoryNoteView);
    }
}
