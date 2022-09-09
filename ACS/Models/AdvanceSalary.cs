using ACS.Models.Common_Model;

namespace ACS.Models
{
    public class AdvanceSalary : CommonModel
    {
        public int AdvanceSalaryID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public double AdvSalary { get; set; }
        public Employee Employee { get; set; }
    }
}
