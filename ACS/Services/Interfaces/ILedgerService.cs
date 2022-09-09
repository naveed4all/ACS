using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface ILedgerService
    {
        //Fetch-All-Ledgers
        List<LedgerView> GetAllLedgers();
        //Fetch-Ledger-By-ID
        LedgerView GetById(int id);

        //Add-Ledger
        Task<LedgerView> AddLedger(LedgerView ledgerView);

        //Update-Ledger
        Task<LedgerView> UpdateLedger(LedgerView ledgerView);
        //Delete-Ledger
        Task<bool> DeleteLedger(int id);
    }
}
