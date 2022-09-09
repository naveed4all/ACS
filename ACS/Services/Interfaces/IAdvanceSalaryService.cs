using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface IAdvanceSalaryService
    {
        //Fetch-All-AdvanceSalaries
        List<AdvanceSalaryView> GetAllAdvanceSalaries();
        //Fetch-AdvanceSalary-By-ID
        AdvanceSalaryView GetById(int id);

        //Add-AdvanceSalary
        Task<AdvanceSalaryView> AddAdvanceSalary(AdvanceSalaryView advanceSalaryView);

        //Update-AdvanceSalary
        Task<AdvanceSalaryView> UpdateAdvanceSalary(AdvanceSalaryView advanceSalaryView);
        //Delete-AdvanceSalary
        Task<bool> DeleteAdvanceSalary(int id);
        //Get-Advance-Salary-By-employee-ID
        List<AdvanceSalaryView> GetAllAdvanceSalariesByEmpID(int empID);
    }
}
