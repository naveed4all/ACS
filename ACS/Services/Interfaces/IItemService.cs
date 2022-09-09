using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface IItemService
    {
        ItemView GetById(int id);
        List<ItemView> GetAll();
        Task<bool> DeleteItem(int id);
        Task<ItemView> AddItem(ItemView itemView);
        Task<ItemView> UpdateItem(ItemView itemView);
    }
}
