using ACS.Services.Interfaces;
using ACS.ViewModels;

namespace ACS.Data
{
    public class ItemManagerService
    {

        private readonly IItemService _itemService;
        
        public ItemManagerService(IItemService itemService)
        {
           _itemService = itemService;
        }
        //Add-Item
        public async Task<ItemView> AddItem(ItemView itemView)
        {
            itemView.CreatedDateTime = DateTime.Now;
            itemView.CreatedByUserID = 1;
            itemView = await _itemService.AddItem(itemView);
            return itemView;

        }
        //Get-All-Items
        public List<ItemView> GetAllItems()
        {
            var items = _itemService.GetAll();
            //advanceSalaryViews = advanceSalaryViews.Where(x=>x.Employee.HAs)
            return items;
        }

       

        //Get-Item-By-ID
        public ItemView GetByID(int Id)
        {
            var item = _itemService.GetById(Id);
            return item; 
           
        }

        public async Task<ItemView> UpdateItem(ItemView itemView)
        {
            itemView.UpdatedDateTime = DateTime.Now;
            itemView.UpdatedByUserID = 1;
            itemView = await _itemService.UpdateItem(itemView);

            return itemView;

        }

        //Delete-Employee

        public async Task<bool> DeleteItem(int id)
        {
            return await _itemService.DeleteItem(id);
        }


    }
}
