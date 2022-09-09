using ACS.AppDBContext;
using ACS.Models;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;

namespace ACS.Services
{
    public class LedgerService: ILedgerService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public LedgerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LedgerView> AddLedger(LedgerView ledgerView)
        {
            try
            {
                var ledger = _mapper.Map<Ledger>(ledgerView);
                ledger.IsActive = true;
                _context.Ledger.Add(ledger);
                await _context.SaveChangesAsync();
                return _mapper.Map<LedgerView>(ledger);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Ledger", e);
            }
        }

        public async Task<bool> DeleteLedger(int id)
        {
            var isDeleted = false;
            try
            {
                var ledger = _context.Ledger.FirstOrDefault(x => x.LedgerID == id);
                //_context.Ledger.Remove(ledger);
                if (ledger.IsActive)
                {
                    ledger.IsActive = false;
                    _context.Ledger.Update(ledger);
                    await _context.SaveChangesAsync();
                }
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Ledger", e);
            }
            return isDeleted;
        }

        public List<LedgerView> GetAllLedgers()
        {
            try
            {
                var ledgers = _context.Ledger.Where(x=>x.IsActive==true).ToList();
                return _mapper.Map<List<Ledger>, List<LedgerView>>(ledgers);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Ledgers", e);
            }
        }

        public LedgerView GetById(int id)
        {
            try
            {
                var ledger = _context.Ledger.FirstOrDefault(x => x.LedgerID == id);
                return _mapper.Map<LedgerView>(ledger);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Ledger By Id", e);
            }
        }

        public async Task<LedgerView> UpdateLedger(LedgerView ledgerView)
        {
            try
            {
                var ledger = _mapper.Map<Ledger>(ledgerView);
                _context.Ledger.Update(ledger);
                await _context.SaveChangesAsync();
                return _mapper.Map<LedgerView>(ledger);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Ledger", e);
            }
        }
    }
}
