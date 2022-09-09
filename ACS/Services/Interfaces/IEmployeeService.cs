

using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface IEmployeeService
    {
        //Fetch-All-Employees
        List<EmployeeView> GetAllEmployees(int skip = 0, int take = 10);
        //Fetch-Employee-By-ID
        EmployeeView GetById(int id);

        //Add-Employee
        Task<EmployeeView> AddEmployee(EmployeeView employeeView);

        //Update-Employee
        Task<EmployeeView> UpdateEmployee(EmployeeView employeeView);
        //Delete-Employee
        Task<bool> DeleteEmployee(int id);

    }
}
