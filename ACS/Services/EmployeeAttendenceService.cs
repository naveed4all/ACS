using ACS.AppDBContext;
using ACS.Models;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ACS.Services
{
    public class EmployeeAttendenceService : IEmployeeAttendenceService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeAttendenceService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeAttendenceView> AddEmployeeAttendence(EmployeeAttendenceView employeeAttendenceView)
        {
            try
            {
                var employeeAttendence = _mapper.Map<EmployeeAttendence>(employeeAttendenceView);
                employeeAttendence.IsActive = true;
                _context.EmployeeAttendence.Add(employeeAttendence);
                await _context.SaveChangesAsync();
                return _mapper.Map<EmployeeAttendenceView>(employeeAttendence);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Employee Attendence", e);
            }
        }

        public async Task<bool> DeleteEmployeeAttendence(int id)
        {
            var isDeleted = false;
            try
            {
                var employeeAttendence = _context.EmployeeAttendence.FirstOrDefault(x => x.EmployeeAttendenceID == id);
                //_context.EmployeeAttendence.Remove(employeeAttendence);
                if (employeeAttendence.IsActive)
                {
                    employeeAttendence.IsActive = false;
                    _context.EmployeeAttendence.Update(employeeAttendence);
                    await _context.SaveChangesAsync();
                }
                
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Employee Attendence", e);
            }
            return isDeleted;
        }

        public List<EmployeeAttendenceView> GetAllEmployeeAttendence()
        {
            try
            {
                var employeeAttendences = _context.EmployeeAttendence.ToList();
                return _mapper.Map<List<EmployeeAttendence>, List<EmployeeAttendenceView>>(employeeAttendences);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Employee Attendences", e);
            }
        }

        public EmployeeAttendenceView GetById(int id)
        {
            try
            {
                var employeeAttendence = _context.EmployeeAttendence.FirstOrDefault(x => x.EmployeeAttendenceID == id);
                return _mapper.Map<EmployeeAttendenceView>(employeeAttendence);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Employee Attendence By Id", e);
            }
        }

        public async Task<EmployeeAttendenceView> UpdateEmployeeAttendence(EmployeeAttendenceView employeeAttendenceView)
        {
            try
            {
                var employeeAttendence = _mapper.Map<EmployeeAttendence>(employeeAttendenceView);
                _context.EmployeeAttendence.Update(employeeAttendence);
                await _context.SaveChangesAsync();
                return _mapper.Map<EmployeeAttendenceView>(employeeAttendence);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Employee Attendence", e);
            }
        }
        public EmployeeView GetAttendenceByEmployeeID(int empId)
        {

            try
            {
                var empWithAtt = _context.Employee.Where(x => x.EmployeeID == empId).Include(x => x.EmployeeAttendences).FirstOrDefault();
                return _mapper.Map<EmployeeView>(empWithAtt);
            }
            catch (Exception e)
            {

                throw new Exception("Error Updating Employee Attendence", e);
            }
        }

        public List<EmployeeAttendenceView> GetAllAttendence()
        {
            try
            {
                var empAttendance = _context.EmployeeAttendence
                .Include(x => x.Employee);

                return empAttendance.Select(x => new EmployeeAttendenceView
                {
                    EmployeeAttendenceID = x.EmployeeAttendenceID,
                    EmployeeID = x.EmployeeID,
                    EmployeeName = x.Employee.EmployeeName,
                    IsLeave = x.IsLeave,
                    CheckIn = x.CheckIn,
                    CheckOut = x.CheckOut,
                    IsPresent = x.IsPresent
                })
                    .ToList();

            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Employee Attendances", e);
            }
        }

        
    }
}

