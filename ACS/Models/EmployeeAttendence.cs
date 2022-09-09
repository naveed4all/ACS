using ACS.Models.Common_Model;
namespace ACS.Models
{
    public class EmployeeAttendence : CommonModel
    {
        public int EmployeeAttendenceID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public bool? IsPresent { get; set; }
        public bool? IsLeave { get; set; }

        public DateTime? AttendanceDate { get; set; }

        public Employee Employee { get; set; }
    }
}
