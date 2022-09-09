using ACS.Services.Interfaces;
using ACS.ViewModels;

namespace ACS.Data
{
    public class InventoryManagerService
    {
        private readonly IInventoryService _inventoryService;
        private readonly IItemService _itemService;
        private readonly IPartyService _partyService;
        public InventoryManagerService(IInventoryService inventoryService, IItemService itemService,IPartyService partyService)
        {
            _inventoryService = inventoryService;
            _itemService = itemService;
            _partyService = partyService;
        }

        //Get-All-Inventories

        public List<InventoryView> GetAllInventories()
        {
            var inventoryViews = _inventoryService.GetAll();
            //advanceSalaryViews = advanceSalaryViews.Where(x=>x.Employee.HAs)
            return inventoryViews;
        }


        //Get-All-Items
        public List<ItemView> GetAllItems()
        {
            var items = _itemService.GetAll();
            //advanceSalaryViews = advanceSalaryViews.Where(x=>x.Employee.HAs)
            return items;
        }

        //Get-All-Parties
        //public List<PartyView> GetAllParties()
        //{
        //    var parties = _partyService.GetAll();
        //    //advanceSalaryViews = advanceSalaryViews.Where(x=>x.Employee.HAs)
        //    return parties;
        //}




    }
}
