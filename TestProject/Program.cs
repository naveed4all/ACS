namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Exprected: " + (10 * 2 * 100));
            //Console.WriteLine(calculateAmount(10, DateTime.Now.AddDays(-60), 100));


            //Console.WriteLine("Exprected: " + (10 * 2 * 100));
            //Console.WriteLine(calculateAmount(10, DateTime.Now.AddDays(-33), 100));


            //Console.WriteLine("Exprected: " + (10 * 1 * 100));
            //Console.WriteLine(calculateAmount(10, new DateTime(2022, 07, 30), 100, 2));
            Console.WriteLine(timeConversion());


        }

        public static double calculateAmount(int OutQty, DateTime inwardDate, double rent, int DaysDiscount = 1)
        {

            int MonthPassed = 1;

            var TodayDate = DateTime.UtcNow.AddHours(5).Date;
            var inwardDatecal = inwardDate.AddDays(DaysDiscount); 

            while (true)
            {
                inwardDatecal = inwardDatecal.AddMonths(1);

                if (TodayDate > inwardDatecal)
                {
                    MonthPassed++;
                }
                else
                {
                    break;
                }
            }


            return OutQty * rent * MonthPassed;

        }

        public static string timeConversion(string s = "07:05:45PM")
        {
            DateTime d = DateTime.Parse(s);
            return (d.ToString("HH:mm:ss"));
        }
    }
}