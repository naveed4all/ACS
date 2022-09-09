using ACS.Services.Interfaces;
using ACS.ViewModels;

namespace ACS.Data
{
    public class StockOutManagerService
    {
        private readonly IStockOutService _stockOutService;
        private readonly IInvoiceService _invoiceService;
        private readonly IInventoryService _inventoryService;
        private readonly IPartyService _partyService;
        private readonly ILedgerService _ledgerService;
        private readonly IPartyLedgerService _partyLedgerService;
        public StockOutManagerService(IStockOutService stockOutService, IInventoryService inventoryService, IPartyService partyService, IInvoiceService invoiceService, ILedgerService ledgerService, IPartyLedgerService partyLedgerService)
        {
            _stockOutService = stockOutService;
            _inventoryService = inventoryService;
            _partyService = partyService;
            _invoiceService = invoiceService;
            _ledgerService = ledgerService;
            _partyLedgerService = partyLedgerService;
        }
        public InventoryView getInventoryDetailsByGRNo(int GRNo)
        {
            return _inventoryService.GetByGRNo(GRNo);
        }
        public List<PartyView> getParties()
        {
            return _partyService.GetAll();
        }
       
        //public async Task<List<StockOutView>> createStockOut(List<StockOutView> stockOutList)
        //{
        //    //stockOutList.ForEach(x => x.CreatedByUserID = 1);

        //    //await _stockOutService.AddStockOutByList(stockOutList);

        //    foreach (var item in stockOutList)
        //    {
        //        if (item.Inventory.Qty >= item.Qty)
        //        {
        //            item.CreatedByUserID = 1;

                    
        //            //item.StockOutBillID =
        //            item.Inventory.Qty = item.Inventory.Qty - item.Qty;
        //            await _stockOutService.AddStockOut(item);
        //            item.Inventory = await _inventoryService.UpdateInventory(item.Inventory);
        //        }
        //    }
            
        //    return stockOutList;
        //}
        public async Task<InvoiceView> generateBill(InvoiceView invoiceView)
        {
            if (invoiceView.IsPaid)
            {
                invoiceView.AmountPaid = invoiceView.TotalAmount;
            }
            var stockOutList = invoiceView.StockOutRecords;
            invoiceView.StockOutRecords = new List<StockOutView>();
            invoiceView.CreatedByUserID = 1;
            invoiceView = await _invoiceService.AddInvoice(invoiceView);
            foreach (var stockOut in stockOutList)
            {
                if (stockOut.Inventory.RemainingQty >= stockOut.Qty)
                {
                    stockOut.CreatedByUserID = 1;
                    stockOut.InvoiceID = invoiceView.InvoiceID;
                    stockOut.Inventory.RemainingQty = stockOut.Inventory.RemainingQty - stockOut.Qty;
                    stockOut.Inventory.Item = null;
                    var inven = await _inventoryService.UpdateInventory(stockOut.Inventory);
                    stockOut.Inventory = null;
                    var outStock = await _stockOutService.AddStockOut(stockOut);
                    outStock.Inventory = inven;
                    invoiceView.StockOutRecords.Add(outStock);
                }
            }
            await addLedgerEntry(invoiceView);
            return invoiceView;            
        }
               


        public async Task addLedgerEntry(InvoiceView invoiceView)
        {
            if (invoiceView?.InvoiceID > 0 && invoiceView.IsPaid)
            {
                await _ledgerService.AddLedger(new LedgerView()
                {
                    InvoiceID = invoiceView.InvoiceID,
                    Amount = invoiceView.AmountPaid,
                    Narration = $"Received {invoiceView.AmountPaid} From Invoice No: {invoiceView.InvoiceID}.",
                    Date = invoiceView.Date,
                    CreatedByUserID = 1
                });
               await updatePartyLedger(invoiceView);
            }
        }

        public async Task updatePartyLedger(InvoiceView invoiceView)
        {
            var partyLedger = _partyLedgerService.GetByPartyId(invoiceView.ReceivedByPartyID);
            partyLedger.TodayCredit += invoiceView.TotalAmount;
            partyLedger.TodayDebit += invoiceView.AmountPaid;
            await _partyLedgerService.UpdatePartyLedger(partyLedger);
        }
        //public async Task<bool> deleteStockOut(StockOutView stockOut)
        //{
        //    var inventory = _inventoryService.GetById(stockOut.InventoryID);
        //    inventory.Qty = inventory.Qty + stockOut.Qty;
        //    await _inventoryService.UpdateInventory(inventory);
        //    return await _stockOutService.DeleteStockOut(stockOut.StockOutID);
        //}
        public double calculateAmount(int OutQty, DateTime inwardDate, double rent, int DaysDiscount = 1,double Discount = 0)
        {

            int MonthPassed = 1;

            var TodayDate = DateTime.UtcNow.AddHours(5).Date;
            var inwardDatecal = inwardDate.AddDays(DaysDiscount);

            while (true)
            {
                inwardDatecal = inwardDatecal.AddMonths(1);

                if (TodayDate > inwardDatecal)
                {
                    MonthPassed++;
                }
                else
                {
                    break;
                }
            }

            var amount = OutQty * MonthPassed * (rent - Discount);
            return amount;

        }
    }
}
