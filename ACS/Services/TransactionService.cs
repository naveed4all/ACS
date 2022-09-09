using ACS.AppDBContext;
using ACS.Models;
using ACS.Pages.ShipmentDetails;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ACS.Services
{
    public class TransactionService:ITransactionService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TransactionService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TransactionView> AddTransaction(TransactionView transactionView)
        {
            try
            {
                var transaction = _mapper.Map<Transaction>(transactionView);
                transaction.IsActive = true;
                transaction.CreatedDateTime = DateTime.Now;
                transaction.CreatedByUserID = 1;

                _context.Transaction.Add(transaction);
                await _context.SaveChangesAsync();
                return _mapper.Map<TransactionView>(GetById(transaction.TransactionID));
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Transaction", e);
            }
        }

        public async Task<bool> DeleteTransaction(int id)
        {
            var isDeleted = false;
            try
            {
                var transaction = _context.Transaction.FirstOrDefault(x => x.TransactionID == id);
                //_context.AdvanceSalary.Remove(advanceSalary);
                if (transaction.IsActive)
                {
                    transaction.IsActive = false;
                    _context.Transaction.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Transaction", e);
            }
            return isDeleted;
        }

        public List<TransactionView> GetAllTransactions()
        {
            try
            {
                //var advanceSalaries = _context.AdvanceSalary.ToList();
                var transactions = _context.Transaction.Where(x => x.IsActive == true).Include(x=>x.Category).AsNoTracking().ToList();
                return _mapper.Map<List<Transaction>, List<TransactionView>>(transactions);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Transactions", e);
            }
        }

        public List<TransactionView> GetAllTransactionsByCatID(int catID)
        {
            try
            {
                var transactions = _context.Transaction.Where(x => x.CategoryID == catID).AsNoTracking().ToList();
                return _mapper.Map<List<Transaction>, List<TransactionView>>(transactions);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Transactions", e);
            }
        }

        public TransactionView GetById(int id)
        {
            try
            {
                var transaction = _context.Transaction.AsNoTracking().FirstOrDefault(x => x.TransactionID == id);
                return _mapper.Map<TransactionView>(transaction);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Transaction By Id", e);
            }
        }

        public async Task<TransactionView> UpdateTransaction(TransactionView transactionView)
        {
            try { 


                transactionView.Category = null;
            var transaction = _mapper.Map<Transaction>(transactionView);
                _context.ChangeTracker.Clear();
                _context.Transaction.Update(transaction);
                await _context.SaveChangesAsync();
                return _mapper.Map<TransactionView>(transaction);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Transaction", e);
            }
        }
    }
}
