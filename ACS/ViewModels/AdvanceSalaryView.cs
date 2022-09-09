using ACS.Models;
using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class AdvanceSalaryView : CommonModel
    {
        public int AdvanceSalaryID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow.AddHours(5);
        public double AdvSalary { get; set; }

        public EmployeeView Employee { get; set; }
    }
}
