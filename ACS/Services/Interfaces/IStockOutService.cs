using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface IStockOutService
    {
        StockOutView GetById(int id);
        List<StockOutView> GetAll();
        Task<bool> DeleteStockOut(int id);
        Task<StockOutView> AddStockOut(StockOutView stockOutView);
        Task<List<StockOutView>> AddStockOutByList(List<StockOutView> stockOutViews);
        Task<StockOutView> UpdateStockOut(StockOutView stockOutView);
    }
}
