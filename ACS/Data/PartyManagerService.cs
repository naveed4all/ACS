using ACS.AppDBContext;
using ACS.Services.Interfaces;
using ACS.ViewModels;

namespace ACS.Data
{
    public class PartyManagerService
    {

        private readonly IPartyService _partyService;
        private readonly IPartyLedgerService _partyLedgerService;
   

        public PartyManagerService(IPartyService partyService, IPartyLedgerService partyLedgerService)
        {
            _partyService = partyService;
            _partyLedgerService = partyLedgerService;
        }
        public List<PartyView> GetAllParties()
        {
            var parties = _partyService.GetAll();
            return(parties);
        }
        public async Task<PartyView> AddParty(PartyView partyView)
        {
            partyView.CreatedDateTime = DateTime.UtcNow.AddHours(5);
            partyView.CreatedByUserID = 1;
            partyView = await _partyService.AddParty(partyView);

            //Opening PartyLedger
            if (partyView?.PartyID > 0)
            {
                await _partyLedgerService.AddPartyLedger(new PartyLedgerView()
                {
                    PartyID = partyView.PartyID,
                    CreatedByUserID = 1,
                });
            }

            return partyView;

        }

        //Update-Party

        public PartyView GetById(int id)
        {
            return _partyService.GetById(id);
        }

        public async Task<PartyView> UpdateParty(PartyView partyView)
        {
            partyView.UpdatedDateTime = DateTime.Now;
            partyView.UpdatedByUserID = 1;
            partyView = await _partyService.UpdateParty(partyView);

            return partyView;
            
        }


        //Delete-Party

        public async Task<bool> DeleteParty(int id)
        {
            return await _partyService.DeleteParty(id);
        }


    }
}
