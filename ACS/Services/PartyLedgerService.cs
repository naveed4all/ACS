using ACS.AppDBContext;
using ACS.Models;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ACS.Services
{
    public class PartyLedgerService: IPartyLedgerService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public PartyLedgerService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PartyLedgerView> AddPartyLedger(PartyLedgerView partyLedgerView)
        {
            try
            {
                var partyLedger = _mapper.Map<PartyLedger>(partyLedgerView);
                partyLedger.IsActive = true;
                _context.PartyLedger.Add(partyLedger);
                await _context.SaveChangesAsync();
                return _mapper.Map<PartyLedgerView>(partyLedger);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Party Ledger", e);
            }
        }

        public async Task<bool> DeletePartyLedger(int id)
        {
            var isDeleted = false;
            try
            {
                var partyLedger = _context.PartyLedger.FirstOrDefault(x => x.PartyLedgerID == id);
                //_context.PartyLedger.Remove(partyLedger);
                if (partyLedger.IsActive)
                {
                    partyLedger.IsActive = false;
                    _context.PartyLedger.Update(partyLedger);
                    await _context.SaveChangesAsync();
                }

                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Party Ledger", e);
            }
            return isDeleted;
        }

        public List<PartyLedgerView> GetAllPartyLedgers()
        {
            try
            {
                var partyLedgers = _context.PartyLedger.Where(x=>x.IsActive==true).ToList();
                return _mapper.Map<List<PartyLedger>, List<PartyLedgerView>>(partyLedgers);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Party Ledgers", e);
            }
        }

        public PartyLedgerView GetById(int id)
        {
            try
            {
                var partyLedger = _context.PartyLedger.FirstOrDefault(x => x.PartyLedgerID == id);
                return _mapper.Map<PartyLedgerView>(partyLedger);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Party Ledger By Id", e);
            }
        }
         public PartyLedgerView GetByPartyId(int partyId)
         {
            try
            {
                var partyLedger = _context.PartyLedger.AsNoTracking().FirstOrDefault(x => x.PartyID == partyId);
                return _mapper.Map<PartyLedgerView>(partyLedger);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Party Ledger By Party Id", e);
            }
         } 

        public async Task<PartyLedgerView> UpdatePartyLedger(PartyLedgerView partyLedgerView)
        {
            try
            {
                var partyLedger = _mapper.Map<PartyLedger>(partyLedgerView);
                _context.PartyLedger.Update(partyLedger);
                await _context.SaveChangesAsync();
                return _mapper.Map<PartyLedgerView>(partyLedger);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Party Ledger", e);
            }
        }
    }
}
