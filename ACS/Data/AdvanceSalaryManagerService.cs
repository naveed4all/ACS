using ACS.Services.Interfaces;
using ACS.ViewModels;

namespace ACS.Data
{
    public class AdvanceSalaryManagerService
    {

        private readonly IAdvanceSalaryService _advanceSalaryService;
        private readonly IEmployeeService _employeeService;
        public AdvanceSalaryManagerService(IAdvanceSalaryService advanceSalaryService, IEmployeeService employeeService)
        {
            _advanceSalaryService = advanceSalaryService;
            _employeeService = employeeService;
        }
        //Add-Advance-Salary
        public async Task<AdvanceSalaryView> AddAdvanceSalary(AdvanceSalaryView advanceSalaryView)
        {
            advanceSalaryView.CreatedDateTime = DateTime.Now;
            advanceSalaryView.CreatedByUserID = 1;
            advanceSalaryView = await _advanceSalaryService.AddAdvanceSalary(advanceSalaryView);
           



            return advanceSalaryView;

        }
        //Get-All-Advance-Salary
        public List<AdvanceSalaryView> GetAllAdvanceSalaries()
        {
            var advanceSalaryViews = _advanceSalaryService.GetAllAdvanceSalaries();
            //advanceSalaryViews = advanceSalaryViews.Where(x=>x.Employee.HAs)
            return advanceSalaryViews;
        }

        //Get-All-Employees
        public List<EmployeeView> GetAllEmployees()
        {
            var employeeView = _employeeService.GetAllEmployees();
            employeeView = employeeView.Where(x => x.HasLeft == false).ToList();
            return employeeView;
        }


        //Get-Advance-Salary-By-ID
        public AdvanceSalaryView GetById(int id)
        {
            return _advanceSalaryService.GetById(id);
        }
        //Get-Employee-By-ID
        public EmployeeView GetEmpById(int id)
        {
            return _employeeService.GetById(id);
        }

        //Get-Advance-Salary-By-Employee-ID
        public List<AdvanceSalaryView> GetAllAdvanceSalariesByEmpID(int empID)
        {
            var advanceSalaryWithEmpID = _advanceSalaryService.GetAllAdvanceSalariesByEmpID(empID);
            return advanceSalaryWithEmpID;
        }

        //Update-Advance-Salary
        public async Task<AdvanceSalaryView> UpdateAdvanceSalary(AdvanceSalaryView advanceSalaryView)
        {
            advanceSalaryView.UpdatedDateTime = DateTime.Now;
            advanceSalaryView.UpdatedByUserID = 1;
            advanceSalaryView = await _advanceSalaryService.UpdateAdvanceSalary(advanceSalaryView);

            return advanceSalaryView;

        }

        //Delete-Advance-Salary

        public async Task<bool> DeleteAdvanceSalary(int id)
        {
            return await _advanceSalaryService.DeleteAdvanceSalary(id);
        }


    }
}
