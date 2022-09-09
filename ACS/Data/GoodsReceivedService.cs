using ACS.Services;
using ACS.Services.Interfaces;
using ACS.ViewModels;

namespace ACS.Data
{
    public class GoodsReceivedService
    {
        private readonly IInventoryService _inventoryService;
        private readonly ISizeService _sizeService;
        private readonly IItemService _itemService;
        private readonly IPartyService _partyService;
        public GoodsReceivedService(IInventoryService inventoryService, ISizeService sizeService, IItemService itemService, IPartyService partyService)
        {
            _inventoryService = inventoryService;
            _sizeService = sizeService;
            _itemService = itemService;
            _partyService = partyService;
        }
        public async Task<InventoryView> SaveGoodsReceived(InventoryView inventoryView)
        {
            inventoryView.CreatedDateTime = DateTime.Now;
            inventoryView.CreatedByUserID = 1;
            inventoryView.RemainingQty = inventoryView.StockInQty;
            inventoryView = await _inventoryService.AddInventory(inventoryView);
            return inventoryView;
        }

        //Update-Goods Received
        public async Task<InventoryView> UpdateGoodsReceived(InventoryView inventoryView)
        {
            inventoryView.UpdatedDateTime = DateTime.Now;
            inventoryView.UpdatedByUserID = 1;
            inventoryView = await _inventoryService.UpdateInventory(inventoryView);

            return inventoryView;
        }

        //Get-Employee-By-ID

        public InventoryView GetById(int id)
        {
            return _inventoryService.GetById(id);
        }

        public Tuple<List<PartyView>,List<ItemView>,List<SizeView>,int> GetGoodsReceiveData()
        {
            var GRNo = _inventoryService.GetGRNo();
            var parties = _partyService.GetAll();
            var items = _itemService.GetAll();
            var sizes = _sizeService.GetAll();
            return Tuple.Create(parties, items, sizes,GRNo);
        }
        public List<PartyView> getParties()
        {
           return _partyService.GetAll();
        }   
        public List<ItemView> getItems()
        {
           return _itemService.GetAll();
        }   
        public List<SizeView> getSizes()
        {
           return _sizeService.GetAll();
        }  
        public int getNewGRNo()
        {
           return _inventoryService.GetGRNo();
        }
        public async Task<ItemView> CreateItem(ItemView itemView)
        {
            itemView.CreatedDateTime = DateTime.Now;
            itemView.CreatedByUserID = 1;
            itemView = await _itemService.AddItem(itemView);
            return itemView;
        }
       
    }
}
