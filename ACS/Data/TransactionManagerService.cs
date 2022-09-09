using ACS.Services.Interfaces;
using ACS.ViewModels;

namespace ACS.Data
{
    public class TransactionManagerService
    {
        private readonly ITransactionService _transactionService;
        private readonly ICategoryService _categoryService;
        public TransactionManagerService(ITransactionService transactionService, ICategoryService categoryService)
        {
            _transactionService = transactionService;
            _categoryService = categoryService;
        }

        //Get-All-Transactions

        public List<TransactionView> GetAllTransactions()
        {
            var transactions = _transactionService.GetAllTransactions();
            return (transactions);
        }

        //Get-All-Categories

        public List<CategoryView> GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return (categories);
        }

        //Add-Transaction

        public async Task<TransactionView> AddTransaction(TransactionView transactionView)
        {
            transactionView.IsActive = true;
            transactionView.CreatedDateTime = DateTime.Now;
            transactionView.CreatedByUserID = 1;
            transactionView = await _transactionService.AddTransaction(transactionView);

            return transactionView;
        }

        //Get-Transaction-By-ID
        public TransactionView GetById(int id)
        {
            return _transactionService.GetById(id);
        }

        //Get-Category-By-ID
        public CategoryView GetCatById(int id)
        {
            return _categoryService.GetById(id);
        }

        //Update-Transaction
        public async Task<TransactionView> UpdateTransaction(TransactionView transactionView)
        {
            transactionView.UpdatedDateTime = DateTime.Now;
            transactionView.UpdatedByUserID = 1;
            transactionView = await _transactionService.UpdateTransaction(transactionView);

            return transactionView;

        }

        //Delete-Transaction

        public async Task<bool> DeleteTransaction(int id)
        {
            return await _transactionService.DeleteTransaction(id);
        }
    }
}
