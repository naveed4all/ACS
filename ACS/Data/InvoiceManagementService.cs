using ACS.Services.Interfaces;
using ACS.ViewModels;

namespace ACS.Data
{
    public class InvoiceManagementService
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IStockOutService _stockOutService;      
        private readonly IStockOutBillService _stockOutBillService;
        private readonly IPartyService _partyService;

        public InvoiceManagementService(IInvoiceService invoiceService, IStockOutService stockOutService, IPartyService partyService, IStockOutBillService stockOutBillService)
        {         
            _invoiceService = invoiceService;
            _stockOutService = stockOutService;
            _partyService = partyService;
            _stockOutBillService = stockOutBillService;
        }

        public async Task<InvoiceView> AddInvoiceRecord(InvoiceView invoiceView)
        {
            invoiceView.CreatedDateTime = DateTime.Now;
            invoiceView.CreatedByUserID = 1;
            invoiceView = await _invoiceService.AddInvoice(invoiceView);
            return invoiceView;
        }

        
    }
}
