using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface IInventoryService
    {
        InventoryView GetById(int id);
        List<InventoryView> GetAll();
        Task<bool> DeleteInventory(int id);
        Task<InventoryView> AddInventory(InventoryView inventoryView);
        Task<InventoryView> UpdateInventory(InventoryView inventoryView);
        int GetGRNo();
        InventoryView GetByGRNo(int gR);
        Task<List<InventoryView>> UpdateInventoryList(List<InventoryView> inventoryViewlist);
    }
}
