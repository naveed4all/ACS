using ACS.Models;
using ACS.Models.Common_Model;

namespace ACS.ViewModels
{
    public class EmployeeAttendenceView : CommonModel
    {
        public int EmployeeAttendenceID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public bool? IsPresent { get; set; }
        public bool? IsLeave { get; set; }

        public DateTime AttendanceDate { get; set; }
        public string EmployeeName { get; set; }
    
        //public Employee Employee { get; set; }
    }
}
