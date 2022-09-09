using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface IPartyService
    {
        PartyView GetById(int id);
        List<PartyView> GetAll();
        Task<bool> DeleteParty(int id);
        Task<PartyView> AddParty(PartyView partyView);
        Task<PartyView> UpdateParty(PartyView partyView);
    }
}
