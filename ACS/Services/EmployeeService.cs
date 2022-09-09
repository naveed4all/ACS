using ACS.AppDBContext;
using ACS.Models;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ACS.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<EmployeeView> AddEmployee(EmployeeView employeeView)
        {
            try
            {
                var employee = _mapper.Map<Employee>(employeeView);
                employee.IsActive = true;
                _context.Employee.Add(employee);
                await _context.SaveChangesAsync();
                return _mapper.Map<EmployeeView>(employee);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Employee", e);
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var isDeleted = false;
            try
            {
                //var advSalaries = _context.AdvanceSalary.Where(x => x.EmployeeID == id).ToList();
                //_context.AdvanceSalary.RemoveRange(advSalaries);
                //var empAttendence = _context.EmployeeAttendence.Where(x => x.EmployeeID == id).ToList();
                //_context.EmployeeAttendence.RemoveRange(empAttendence);

                var employee = _context.Employee.FirstOrDefault(x => x.EmployeeID == id);
                //_context.Employee.Remove(employee);
                if (employee.IsActive)
                {
                    employee.IsActive = false;
                    _context.Employee.Update(employee);
                    await _context.SaveChangesAsync();
                }
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Employee", e);
            }
            return isDeleted;
        }

        public List<EmployeeView> GetAllEmployees(int Skip = 0, int Take = 10)
        {
            try
            {
                var employees = _context.Employee.AsNoTracking().Where(x=>x.IsActive == true).Skip(Skip).Take(Take).OrderByDescending(x=>x.EmployeeID).AsNoTracking().ToList();
                return _mapper.Map<List<Employee>, List<EmployeeView>>(employees);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Employees", e);
            }
        }

        public EmployeeView GetById(int id)
        {
            try
            {
                var employee = _context.Employee.AsNoTracking().FirstOrDefault(x => x.EmployeeID == id);
                return _mapper.Map<EmployeeView>(employee);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Employee By Id", e);
            }
        }

        public async Task<EmployeeView> UpdateEmployee(EmployeeView employeeView)
        {
            try
            {
                var employee = _mapper.Map<Employee>(employeeView);
                _context.ChangeTracker.Clear();
                _context.Employee.Update(employee);
                await _context.SaveChangesAsync();
                return _mapper.Map<EmployeeView>(GetById(employee.EmployeeID));
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Employees", e);
            }
        }

      
    }
}
