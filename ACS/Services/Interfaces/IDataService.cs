using ACS.ViewModels;
using ACS.ViewModels.DataView;
using static ACS.ViewModels.DataView.DashboardView;

namespace ACS.Services.Interfaces
{
    public interface IDataService
    {
        List<YearlyItem> LoadCurrentYearExpenses();
        List<YearlyItem> LoadCurrentYearRevenues();
        Task<LastMonthsData> LoadLastMonthExpenses();
        Task<LastMonthsData> LoadLastMonthRevenues();

        IEnumerable<RevenueByMonth> RevenueByMonth();
        IEnumerable<ExpenseByMonth> ExpenseByMonth();




        // Task<Stats> MonthlyStats();

        //IEnumerable<RevenueByCategory> RevenueByCategory();
        //IEnumerable<RevenueByCategory> RevenueByEmployee();
        //IEnumerable<RevenueByMonth> RevenueByMonth();
        //IEnumerable<ExpenseByMonth> ExpenseByMonth();

        //  List<RevenueByCompany> RevenueByCompany();

    }
}
