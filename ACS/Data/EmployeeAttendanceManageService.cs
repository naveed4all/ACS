using ACS.Services;
using ACS.Services.Interfaces;
using ACS.ViewModels;

namespace ACS.Data
{
    public class EmployeeAttendanceManageService
    {
        private readonly IEmployeeAttendenceService _employeeAttendenceService;
        private readonly IEmployeeService _employee;

        public EmployeeAttendanceManageService(IEmployeeAttendenceService employeeAttendenceService, IEmployeeService employee)
        {
            _employeeAttendenceService = employeeAttendenceService;
            _employee = employee;
        }
       
        // Get-All-Employees-Attendance

        public List<EmployeeAttendenceView> GetAllEmployeeAttendance()
        {
            var employeeAttendance = _employeeAttendenceService.GetAllAttendence();
            return employeeAttendance;
        }

        //Add-Employees-Attendance
        public async Task<EmployeeAttendenceView> AddEmployeeAttendence(EmployeeAttendenceView employeeAttendence)
        {
            employeeAttendence.CreatedDateTime = DateTime.UtcNow;
            employeeAttendence.CreatedByUserID = 1;
            employeeAttendence = await _employeeAttendenceService.AddEmployeeAttendence(employeeAttendence);
            return employeeAttendence;
        }

        //Update-Employees-Attendance
        public async Task<EmployeeAttendenceView> UpdateEmployeeAttendence(EmployeeAttendenceView employeeAttendence)
        {
            employeeAttendence.CreatedDateTime = DateTime.UtcNow;
            employeeAttendence.CreatedByUserID = 1;
            employeeAttendence = await _employeeAttendenceService.UpdateEmployeeAttendence(employeeAttendence);
            return employeeAttendence;
        }

        public EmployeeAttendenceView GetById(int id)
        {
            return _employeeAttendenceService.GetById(id);
        }

        public List<EmployeeView> GetEmployees()
        {
            var Employees = _employee.GetAllEmployees();
            return Employees;
        }

        

    }
}
