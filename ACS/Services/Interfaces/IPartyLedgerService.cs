using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface IPartyLedgerService
    {
        //Fetch-All-Party-Ledgers
        List<PartyLedgerView> GetAllPartyLedgers();
        //Fetch-Party-Ledger-By-ID
        PartyLedgerView GetById(int id);
        //Fetch-Party-Ledger-By-PartyID
        PartyLedgerView GetByPartyId(int partyId);

        //Add-Party-Ledger
        Task<PartyLedgerView> AddPartyLedger(PartyLedgerView partyLedgerView);

        //Update-Party-Ledger
        Task<PartyLedgerView> UpdatePartyLedger(PartyLedgerView partyLedgerView);
        //Delete-Party-Ledger
        Task<bool> DeletePartyLedger(int id);
    }
}
