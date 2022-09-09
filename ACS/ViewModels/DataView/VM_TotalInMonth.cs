namespace ACS.ViewModels.DataView
{
    public class CustomData
    {
        public int Id { get; set; }
        public List<Tuple<string, decimal>> TotalInMonth { get; set; }
    }

    public class VM_MouthWiseTotalInMonth
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public List<string> Month { get; set; }
        public List<decimal> Total { get; set; }
        public List<CustomData> TotalInMonths { get; set; }
    }
}
