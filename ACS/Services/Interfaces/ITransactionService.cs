using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface ITransactionService
    {

        //Fetch-All-Transactions
        List<TransactionView> GetAllTransactions();
        //Fetch-Transaction-By-ID
        TransactionView GetById(int id);

        //Add-Transaction
        Task<TransactionView> AddTransaction(TransactionView transactionView);

        //Update-Transaction
        Task<TransactionView> UpdateTransaction(TransactionView transactionView);
        //Delete-Transaction
        Task<bool> DeleteTransaction(int id);
        //Get-Transaction-By-Category-ID
        List<TransactionView> GetAllTransactionsByCatID(int id);
    }
}
