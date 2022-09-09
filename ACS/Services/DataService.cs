using ACS.AppDBContext;
using ACS.Services.Interfaces;
using ACS.ViewModels.DataView;
using Microsoft.EntityFrameworkCore;
using System;
using static ACS.ViewModels.DataView.DashboardView;

namespace ACS.Services
{
    public class DataService : IDataService
    {

        private readonly AppDbContext _context;
        private readonly int _currentYear = DateTime.Today.Year;
        private readonly DateTime CurrentDate = DateTime.UtcNow;

        public DataService(AppDbContext context)
        {
            _context = context;
        }


        public List<YearlyItem> LoadCurrentYearRevenues()
        {

            var data = _context.Transaction.Include(x => x.Category).ToList();
            return data.Where(revenue => revenue.Date >= new DateTime(_currentYear, 1, 1)
                && revenue.Date <= new DateTime(_currentYear, 12, 31))
                .GroupBy(revenue => revenue.Date.Month)
                .OrderBy(revenue => revenue.Key)
                .Select(revenue => new YearlyItem
                {
                    Month = GetMonthAsText(revenue.Key, _currentYear),
                    Amount = revenue.Sum(item => item.Amount)
                })
                .ToList();
        }

        public List<YearlyItem> LoadCurrentYearExpenses()
        {
            var data = _context.Transaction.Include(x => x.Category).ToList();
            return data.Where(expense => expense.Date >= new DateTime(_currentYear, 1, 1)
                && expense.Date <= new DateTime(_currentYear, 12, 31))
                .GroupBy(expense => expense.Date.Month)
                .OrderBy(expense => expense.Key)
                .Select(expense => new YearlyItem
                {
                    Month = GetMonthAsText(expense.Key, _currentYear),
                    Amount = expense.Sum(item => item.Amount)
                })
                .ToList();
        }


        public async Task<LastMonthsData> LoadLastMonthRevenues()
        {
            var currentMonth = DateTime.Today.Month;
            // var lastMonth = DateTime.Today.AddMonths(-1);
            //  var previousMonth = DateTime.Today.AddMonths(-2);

            return new LastMonthsData
            {
                CurrentMonth = new MonthlyData
                {
                    Data = await GetMonthlyRevenues(currentMonth, _currentYear),
                    Label = GetMonthAsText(currentMonth, _currentYear)
                },
                //LastMonth = new MonthlyData
                //{
                //    Data = await GetMonthlyRevenues(lastMonth.Month, lastMonth.Year),
                //    Label = GetMonthAsText(lastMonth.Month, lastMonth.Year)
                //},
                //PreviousMonth = new MonthlyData
                //{
                //    Data = await GetMonthlyRevenues(previousMonth.Month, previousMonth.Year),
                //    Label = GetMonthAsText(previousMonth.Month, previousMonth.Year)
                //}
            };
        }

        private async Task<List<MonthlyItem>> GetMonthlyRevenues(int month, int year)
        {
            var data = await _context.PartyLedger.Include(x => x.Party).ToListAsync();
            return data.Where(revenue => revenue.CreatedDateTime.Date >= new DateTime(year, month, 1)
                && revenue.CreatedDateTime.Date <= new DateTime(year, month, LastDayOfMonth(month, year)))
               .GroupBy(revenue => new DateTime(revenue.CreatedDateTime.Year, revenue.CreatedDateTime.Month, 1))
                .Select(revenue => new MonthlyItem
                {
                    Amount = revenue.Sum(item => Convert.ToDecimal(item.TodayCredit)),
                    Category = revenue.Key.ToString()
                })
                .ToList();
        }


        public async Task<LastMonthsData> LoadLastMonthExpenses()
        {
            var currentMonth = DateTime.Today.Month;
            //  var lastMonth = DateTime.Today.AddMonths(-1);
            //var previousMonth = DateTime.Today.AddMonths(-2);

            return new LastMonthsData
            {
                CurrentMonth = new MonthlyData
                {
                    Data = await GetMonthlyExpenses(currentMonth, _currentYear),
                    Label = GetMonthAsText(currentMonth, _currentYear)
                },
                //LastMonth = new MonthlyData
                //{
                //    Data = await GetMonthlyExpenses(lastMonth.Month, lastMonth.Year),
                //    Label = GetMonthAsText(lastMonth.Month, lastMonth.Year)
                //}
                //PreviousMonth = new MonthlyData
                //{
                //    Data = await GetMonthlyExpenses(previousMonth.Month, previousMonth.Year),
                //    Label = GetMonthAsText(previousMonth.Month, previousMonth.Year)
                //}
            };
        }

        private async Task<List<MonthlyItem>> GetMonthlyExpenses(int month, int year)
        {
            var data = await _context.PartyLedger.Include(x => x.Party).ToListAsync();
            return data.Where(expense => expense.CreatedDateTime.Date >= new DateTime(year, month, 1)
                && expense.CreatedDateTime.Date <= new DateTime(year, month, LastDayOfMonth(month, year)))
               .GroupBy(expense => new DateTime(expense.CreatedDateTime.Year, expense.CreatedDateTime.Month, 1))
                .Select(expense => new MonthlyItem
                {
                    Amount = expense.Sum(item => Convert.ToDecimal(item.TodayDebit)),
                    Category = expense.Key.ToString()
                })
                .ToList();
        }


        // private async Task<List<GoodRecieve>> GetItems(int month, int year)
        //{

        //    var data = await _context.Inventory
        //        .Include(x => x.Party)
        //        .Include(x => x.Size)
        //        .Include(x => x.Invoices)
        //        .Include(x => x.Item)
        //        .Include(x => x.StockOuts)
        //        .Include(x => x.InventoryNotes)
        //        .Include(x => x.Invoices)
        //        .ToListAsync();

        //    return data.Where(x => x.ReceivedDate.Date >= new DateTime(year, month, 1)
        //        && x.ReceivedDate.Date <= new DateTime(year, month, LastDayOfMonth(month, year)))
        //       .GroupBy(x => new DateTime(x.ReceivedDate.Year, x.ReceivedDate.Month, 1))
        //        .Select(x => new GoodRecieve
        //        {
        //             Item,
        //             Quantity
        //        })
        //        .ToList();
        //}




        private static int LastDayOfMonth(int month, int year)
        {
            return DateTime.DaysInMonth(year, month);
        }

        private static string GetMonthAsText(int month, int year)
        {
            return month switch
            {
                1 => $"January {year}",
                2 => $"February {year}",
                3 => $"March {year}",
                4 => $"April {year}",
                5 => $"May {year}",
                6 => $"June {year}",
                7 => $"July {year}",
                8 => $"August {year}",
                9 => $"September {year}",
                10 => $"October {year}",
                11 => $"November {year}",
                12 => $"December {year}",
                _ => throw new NotImplementedException(),
            };
        }

        public IEnumerable<RevenueByMonth> RevenueByMonth()
        {
            var data = _context.Transaction
                                 .Include(x => x.Category)
                                 // .Where(x => x.Category.Type == )
                                 .ToList()
                                 .GroupBy(x => new DateTime(x.Date.Year, x.Date.Month, 1))
                                 .Select(group => new RevenueByMonth()
                                 {
                                     Revenue = group.Sum(x => x.Amount),
                                     Month = group.Key
                                 })
                                 .OrderBy(x => x.Month);

            return data.ToList();
        }

        public IEnumerable<ExpenseByMonth> ExpenseByMonth()
        {

            var data = _context.Transaction
                                 .Include(x => x.Category)
                                 //     .Where(x => x.Category.Type == 0)
                                 .ToList()
                                 .GroupBy(x => new DateTime(x.Date.Year, x.Date.Month, 1))
                                 .Select(group => new ExpenseByMonth()
                                 {
                                     Expense = group.Sum(x => x.Amount),
                                     Month = group.Key
                                 })
                                 .OrderBy(x => x.Month);

            return data.ToList();
        }


        public enum Category
        {
            Expense,
            Income
        }

    }
}
