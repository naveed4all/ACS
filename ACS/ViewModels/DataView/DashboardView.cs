namespace ACS.ViewModels.DataView
{
    public class DashboardView
    {
       

            public class ExpenseByMonth
            {
                public DateTime Month { get; set; }
                public decimal Expense { get; set; }
            }

            public class MonthlyData
            {
                public ICollection<MonthlyItem> Data { get; set; }
                public string Label { get; set; }
            }

            public class MonthlyItem
            {
                public decimal Amount { get; set; }
                public string Category { get; set; }

            }

            public class RevenueByCategory
            {
                public string Category { get; set; }
                public decimal Revenue { get; set; }
            }

            public class GoodRecieve
            {
                public string Item { get; set; }
                public int Quantity { get; set; }
            }

            public class RevenueByGoodRecieve
            {
                public string Item { get; set; }
                public decimal Quantity { get; set; }
            }

            public class RevenueByMonth
            {
                public DateTime Month { get; set; }
                public decimal Revenue { get; set; }
            }


            public class YearlyItem
            {
                public string Month { get; set; }
                public decimal Amount { get; set; }
            }
            public class LastMonthsData
            {
                public MonthlyData CurrentMonth { get; set; }
                //  public MonthlyData LastMonth { get; set; }
                //public MonthlyData PreviousMonth { get; set; }
            }









            public class Stats
            {
                public DateTime Month { get; set; }
                public decimal Closingbalance { get; set; }
                public decimal TodayDebit { get; set; }
                public decimal TodayCredit { get; set; }
                //public string VehicleNo { get; set; }
                //public string ShipmentNo { get; set; }
            }

            public class Earning
            {
                public Earning()
                {
                    Id = Guid.NewGuid();
                }
                public Guid Id { get; set; }
                public DateTime Date { get; set; }
                public string Subject { get; set; }
                public EarningCategory Category { get; set; }
                public decimal Amount { get; set; }
            }

            public enum EarningCategory
            {
                Salary,
                CapitalGain,
                Freelancing,
                Coaching,
                Flipping,
                Gift,
            }

            public class Expense
            {
                public Expense()
                {
                    Id = Guid.NewGuid();
                }
                public Guid Id { get; set; }
                public DateTime Date { get; set; }
                public string Subject { get; set; }
                public ExpenseCategory Category { get; set; }
                public decimal Amount { get; set; }
            }

            public enum ExpenseCategory
            {
                Housing,
                Transportation,
                Food,
                Utilities,
                Clothing,
                Healthcare,
                Insurance,
                Personal,
                Debt,
                Retirement,
                Education,
                Savings,
                Gifts,
                Donations,
                Entertainment
            }
        }
    }



