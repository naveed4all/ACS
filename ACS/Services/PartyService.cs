using ACS.AppDBContext;
using ACS.Models;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ACS.Services
{
    public class PartyService : IPartyService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public PartyService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PartyView> AddParty(PartyView partyView)
        {
            try
            {
                var party = _mapper.Map<Party>(partyView);
                party.IsActive = true;
                _context.Party.Add(party);
                await _context.SaveChangesAsync();
                return _mapper.Map<PartyView>(party);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Party", e);
            }
        }

        public async Task<bool> DeleteParty(int id)
        {
            var isDeleted = false;
            try
            {
                var party = _context.Party.FirstOrDefault(x => x.PartyID == id);
                //_context.Party.Remove(party);
                if (party.IsActive)
                {
                    party.IsActive = false;
                    _context.Party.Update(party);
                    await _context.SaveChangesAsync();
                }

                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Party", e);
            }
            return isDeleted;
        }

        public List<PartyView> GetAll()
        {
            try
            {
                var parties = _context.Party.Where(x=>x.IsActive==true).AsNoTracking().ToList();
                return _mapper.Map<List<Party>, List<PartyView>>(parties);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Parties", e);
            }
        }

        public PartyView GetById(int id)
        {
            try
            {
                var party = _context.Party.AsNoTracking().FirstOrDefault(x => x.PartyID == id);
                return _mapper.Map<PartyView>(party);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Party By Id", e);
            }
        }

        public async Task<PartyView> UpdateParty(PartyView partyView)
        {
            try
            {
                var party = _mapper.Map<Party>(partyView);
                _context.ChangeTracker.Clear();
                _context.Party.Update(party);
                await _context.SaveChangesAsync();
                return _mapper.Map<PartyView>(GetById(party.PartyID));
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Party", e);
            }
        }
    }
}
