using ACS.Models;
using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class EmployeeView : CommonModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public double Salary { get; set; }
        public bool IsPermenant { get; set; }
        public string? Contact { get; set; }
        public string? Address { get; set; }
        public bool HasLeft { get; set; }

        //public ICollection<AdvanceSalary> AdvanceSalaries { get; set; }
        public ICollection<EmployeeAttendence> EmployeeAttendences { get; set; }
    }
}
