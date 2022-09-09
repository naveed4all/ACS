using ACS.AppDBContext;
using ACS.Models;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ACS.Services
{
    public class StockOutBillService : IStockOutBillService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public StockOutBillService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //public async Task<StockOutBillView> AddStockOutBill(StockOutBillView billView)
        //{
        //    try
        //    {
        //        billView.IsActive = true;
        //        var bill = _mapper.Map<StockOutBill>(billView);
        //        //_context.StockOutBill.Add(bill);
        //        await _context.SaveChangesAsync();
        //        return _mapper.Map<StockOutBillView>(bill);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Error Adding Stock Out Bill", e);
        //    }
        //}

        //public async Task<bool> DeleteStockOutBill(int id)
        //{
        //    var isDeleted = false;
        //    try
        //    {
        //        //var bill = _context.StockOutBill.FirstOrDefault(x => x.StockOutBillID == id);
        //        //if (bill == null)
        //        //{
        //        //    return true;
        //        //}
        //        //bill.IsActive = false;
        //        //_context.StockOutBill.Update(bill);
        //        await _context.SaveChangesAsync();
        //        isDeleted = true;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Error Updating Stock Out Bill", e);
        //    }
        //    return isDeleted;
        //}

        //public List<StockOutBillView> GetAll()
        //{

        //    try
        //    {
        //        var bill = _context.StockOutBill.AsNoTracking().Where(x => x.IsActive == true).ToList();
        //        return _mapper.Map<List<StockOutBill>, List<StockOutBillView>>(bill);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Error getting all Stock Out Bills", e);
        //    }
        //}

        //public StockOutBillView GetById(int id)
        //{

        //    try
        //    {
        //        var bill = _context.StockOutBill.FirstOrDefault(x => x.StockOutBillID == id);
        //        return _mapper.Map<StockOutBillView>(bill);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Error getting Stock Out Bill by id", e);
        //    }
        //}

        //public async Task<StockOutBillView> UpdateStockOutBill(StockOutBillView billView)
        //{
        //    try
        //    {
        //        var bill = _mapper.Map<StockOutBill>(billView);
        //        _context.StockOutBill.Update(bill);
        //        await _context.SaveChangesAsync();
        //        return _mapper.Map<StockOutBillView>(bill);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Error Updating Stock Out Bill", e);
        //    }
        //}
    }
}
