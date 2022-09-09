using ACS.AppDBContext;
using ACS.Services;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using ACS.ViewModels.DataView;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using static ACS.ViewModels.DataView.DashboardView;

namespace ACS.Data
{
    public class DashBoardDataServices
    {

        private readonly IDataService _dataService;
        private readonly DateTime CurrentDate = DateTime.UtcNow;
        int Month, Year;
        public DashBoardDataServices(IDataService dataService)
        {
            _dataService = dataService;
        }

        public List<YearlyItem> LoadCurrentYearExpenses()
        {
            var expenses = _dataService.LoadCurrentYearExpenses();
            return expenses;
        }


        public List<YearlyItem> LoadCurrentYearRevenues()
        {
            var revenues = _dataService.LoadCurrentYearRevenues();
            return revenues;
        }


        public Task<LastMonthsData> LoadLastMonthRevenues()
        {
            var revenues = _dataService.LoadLastMonthRevenues();
            return revenues;
        }

        public Task<LastMonthsData> LoadLastMonthExpenses()
        {
            var expenses = _dataService.LoadLastMonthExpenses();
            return expenses;
        }

        public IEnumerable<RevenueByMonth> LoadMonthRevenues()
        {
            var revenues = _dataService.RevenueByMonth();
            return revenues;
        }

        public IEnumerable<ExpenseByMonth> LoadMonthExpenses()
        {
            var expenses = _dataService.ExpenseByMonth();
            return expenses;
        }


    }
}
