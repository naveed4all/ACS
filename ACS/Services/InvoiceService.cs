using ACS.AppDBContext;
using ACS.Models;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;

namespace ACS.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public InvoiceService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InvoiceView> AddInvoice(InvoiceView InvoiceView)
        {
            try
            {
                var invoice = _mapper.Map<Invoice>(InvoiceView);
                invoice.IsActive = true;
                _context.Invoice.Add(invoice);
                await _context.SaveChangesAsync();
                return _mapper.Map<InvoiceView>(invoice);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Invoice", e);
            }
        }

        public async Task<bool> DeleteInvoice(int id)
        {
            var isDeleted = false;
            try
            {
                var invoice = _context.Invoice.FirstOrDefault(x => x.InvoiceID == id);
                if (invoice.IsActive)
                {
                 invoice.IsActive = false;
                 _context.Invoice.Update(invoice);
                 await _context.SaveChangesAsync();
                }

                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Invoice", e);
            }
            return isDeleted;
        }

        public List<InvoiceView> GetAll()
        {
            try
            {
                var invoices = _context.Invoice.Where(x=>x.IsActive==true).ToList();
                return _mapper.Map<List<Invoice>, List<InvoiceView>>(invoices);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Invoices", e);
            }
        }

        public InvoiceView GetById(int id)
        {
            try
            {
                var invoice = _context.Invoice.FirstOrDefault(x => x.InvoiceID == id);
                return _mapper.Map<InvoiceView>(invoice);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Invoice By Id", e);
            }
        }

        public async Task<InvoiceView> UpdateInvoice(InvoiceView InvoiceView)
        {
            try
            {
                var invoice = _mapper.Map<Invoice>(InvoiceView);
                _context.Invoice.Update(invoice);
                await _context.SaveChangesAsync();
                return _mapper.Map<InvoiceView>(invoice);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Invoice", e);
            }
        }
    }
}
