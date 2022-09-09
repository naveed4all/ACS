using ACS.AppDBContext;
using ACS.Services.Interfaces;
using ACS.ViewModels;

namespace ACS.Data
{
    public class EmployeeManagerService
    {
        
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeAttendenceService _attendenceService;

        public EmployeeManagerService(IEmployeeService employeeService, IEmployeeAttendenceService attendenceService)
        {
            _employeeService = employeeService;
            _attendenceService = attendenceService;
        }
        public List<EmployeeView> GetAllEmployees(int skip = 0,int take = 10)
        {
            var employees=_employeeService.GetAllEmployees(skip,take);
            return (employees);
        }
        public async Task<EmployeeView> AddEmployee(EmployeeView employeeView)
        {
            employeeView.IsActive = true;
            employeeView.CreatedDateTime = DateTime.Now;
            employeeView.CreatedByUserID = 1;
            employeeView  =await _employeeService.AddEmployee(employeeView);
            
            return employeeView;
            
        }

        //Get-Employee-By-ID

        public  EmployeeView GetById(int id)
        {
            return _employeeService.GetById(id);
        }

        //Update-Employee
        public async Task<EmployeeView> UpdateEmployee(EmployeeView employeeView)
        {
            employeeView.UpdatedDateTime = DateTime.Now;
            employeeView.UpdatedByUserID = 1;
            employeeView = await _employeeService.UpdateEmployee(employeeView);

            return employeeView;

        }


        //Delete-Employee

        public async Task<bool> DeleteEmployee(int id)
        {
            return await _employeeService.DeleteEmployee(id);
        }

        //Mark-Attendence
        public async Task<EmployeeAttendenceView> MarkEmployeeAtt(EmployeeAttendenceView empAttendence)
        {
            empAttendence = await _attendenceService.AddEmployeeAttendence(empAttendence);

            return empAttendence;

        }
        //GetAttendenceByEmployeeID
        public EmployeeView GetEmployeeAttendence(int empID)
        {
           var employee =  _attendenceService.GetAttendenceByEmployeeID(empID);
            return employee;
        }
    }
}
