using ACS.AppDBContext;
using ACS.Models;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ACS.Services
{
    public class AdvanceSalaryService: IAdvanceSalaryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AdvanceSalaryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AdvanceSalaryView> AddAdvanceSalary(AdvanceSalaryView advanceSalaryView)
        {
            try
            {
                var advanceSalary = _mapper.Map<AdvanceSalary>(advanceSalaryView);
                advanceSalary.IsActive = true;
                
                _context.AdvanceSalary.Add(advanceSalary);
                await _context.SaveChangesAsync();
                return _mapper.Map<AdvanceSalaryView>(advanceSalary);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Advance Salary", e);
            }
        }

        public async Task<bool> DeleteAdvanceSalary(int id)
        {
            var isDeleted = false;
            try
            {
                var advanceSalary = _context.AdvanceSalary.FirstOrDefault(x => x.AdvanceSalaryID == id);
                //_context.AdvanceSalary.Remove(advanceSalary);
                if (advanceSalary.IsActive)
                {
                    advanceSalary.IsActive = false;
                    _context.AdvanceSalary.Update(advanceSalary);
                    await _context.SaveChangesAsync();
                }
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Advance Salary", e);
            }
            return isDeleted;
        }

        public List<AdvanceSalaryView> GetAllAdvanceSalaries()
        {
            try
            {
                //var advanceSalaries = _context.AdvanceSalary.ToList();
                var advanceSalaries = _context.AdvanceSalary.Where(x=>x.IsActive==true).AsNoTracking().Include(x=> x.Employee).AsNoTracking().Where(x=>x.Employee.IsActive == true && x.Employee.HasLeft == false).ToList();
                return _mapper.Map<List<AdvanceSalary>, List<AdvanceSalaryView>>(advanceSalaries);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Advance Salaries", e);
            }
        }
        public List<AdvanceSalaryView> GetAllAdvanceSalariesByEmpID(int empID)
        {
            try
            {
                var advanceSalaries = _context.AdvanceSalary.Where(x=>x.EmployeeID==empID).AsNoTracking().ToList();
                return _mapper.Map<List<AdvanceSalary>, List<AdvanceSalaryView>>(advanceSalaries);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Advance Salaries", e);
            }
        }

        public AdvanceSalaryView GetById(int id)
        {
            try
            {
                var advanceSalary = _context.AdvanceSalary.AsNoTracking().Include(x=> x.Employee).AsNoTracking().FirstOrDefault(x => x.AdvanceSalaryID == id);
                return _mapper.Map<AdvanceSalaryView>(advanceSalary);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Advance Salary By Id", e);
            }
        }

        public async Task<AdvanceSalaryView> UpdateAdvanceSalary(AdvanceSalaryView advanceSalaryView)
        {
            try
            {
                advanceSalaryView.Employee = null;
                var advanceSalary = _mapper.Map<AdvanceSalary>(advanceSalaryView);
                _context.ChangeTracker.Clear();
                _context.AdvanceSalary.Update(advanceSalary);
                await _context.SaveChangesAsync();
                return _mapper.Map<AdvanceSalaryView>(GetById(advanceSalary.AdvanceSalaryID));
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Advance Salary", e);
            }
        }
    }
}
