using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface IInvoiceService
    {
        InvoiceView GetById(int id);
        List<InvoiceView> GetAll();
        Task<bool> DeleteInvoice(int id);
        Task<InvoiceView> AddInvoice(InvoiceView InvoiceView);
        Task<InvoiceView> UpdateInvoice(InvoiceView InvoiceView);
    }
}
