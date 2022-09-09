using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface IEmployeeAttendenceService
    {

        //Fetch-All-EmployeeAttendenceServices
        List<EmployeeAttendenceView> GetAllEmployeeAttendence();

        //Fetch-All-AttendenceServices
        List<EmployeeAttendenceView> GetAllAttendence();
        //Fetch-AdvanceSalary-By-ID
        EmployeeAttendenceView GetById(int id);

        //Add-EmployeeAttendence
        Task<EmployeeAttendenceView> AddEmployeeAttendence(EmployeeAttendenceView employeeAttendenceView);

        //Update-EmployeeAttendence
        Task<EmployeeAttendenceView> UpdateEmployeeAttendence(EmployeeAttendenceView employeeAttendenceView);
        //Delete-EmployeeAttendence
        Task<bool> DeleteEmployeeAttendence(int id);

        //Get-Employee-Attendence
        EmployeeView GetAttendenceByEmployeeID(int empId);



    }
}
