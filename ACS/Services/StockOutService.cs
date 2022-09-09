using ACS.AppDBContext;
using ACS.Models;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ACS.Services
{
    public class StockOutService : IStockOutService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public StockOutService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StockOutView> AddStockOut(StockOutView stockOutView)
        {
            try
            {
                var stockOut = _mapper.Map<StockOut>(stockOutView);
                stockOut.IsActive = true;

                _context.StockOut.Add(stockOut);
                await _context.SaveChangesAsync();
                return _mapper.Map<StockOutView>(stockOut);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Stock Out", e);
            }
        }
         public async Task<List<StockOutView>> AddStockOutByList(List<StockOutView> stockOutViews)
         {
            try
            {
                var stockOuts = _mapper.Map<List<StockOutView>, List<StockOut>>(stockOutViews);
                _context.StockOut.AddRange(stockOuts);
                await _context.SaveChangesAsync();
                return _mapper.Map<List<StockOut>, List<StockOutView>>(stockOuts);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Stock Out", e);
            }
         }

        public async Task<bool> DeleteStockOut(int id)
        {
            var isDeleted = false;
            try
            {
                var stockOut = _context.StockOut.FirstOrDefault(x => x.StockOutID == id);
                //_context.StockOut.Remove(stockOut);
                if (stockOut.IsActive)
                {
                    stockOut.IsActive = false;
                    _context.StockOut.Update(stockOut);
                    await _context.SaveChangesAsync();
                }
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Stock Out", e);
            }
            return isDeleted;
        }

        public List<StockOutView> GetAll()
        {
            try
            {
                var stocksOut = _context.StockOut.Where(x=>x.IsActive==true).ToList();
                return _mapper.Map<List<StockOut>, List<StockOutView>>(stocksOut);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Stocks Out", e);
            }
        }

        public StockOutView GetById(int id)
        {
            try
            {
                var stockOut = _context.StockOut.FirstOrDefault(x => x.StockOutID == id);
                return _mapper.Map<StockOutView>(stockOut);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Party Ledger By Id", e);
            }
        }

        public async Task<StockOutView> UpdateStockOut(StockOutView stockOutView)
        {
            try
            {
                var stockOut = _mapper.Map<StockOut>(stockOutView);
                _context.StockOut.Update(stockOut);
                await _context.SaveChangesAsync();
                return _mapper.Map<StockOutView>(stockOut);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Stock Out", e);
            }
        }
       
    }
}
