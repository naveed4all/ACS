using ACS.AppDBContext;
using ACS.Models;
using ACS.Pages.ShipmentDetails;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ACS.Services
{

    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CategoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       

        public async Task<CategoryView> AddCategory(CategoryView categoryView)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryView);
                category.IsActive = true;

                _context.Category.Add(category);
                await _context.SaveChangesAsync();
                return _mapper.Map<CategoryView>(GetById(category.CategoryID));
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Category", e);
            }
        }

       

        public async Task<bool> DeleteCategory(int id)
        {
            var isDeleted = false;
            try
            {
                var category = _context.Category.FirstOrDefault(x => x.CategoryID == id);
                //_context.AdvanceSalary.Remove(advanceSalary);
                if (category.IsActive)
                {
                    category.IsActive = false;
                    _context.Category.Update(category);
                    await _context.SaveChangesAsync();
                }
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Category", e);
            }
            return isDeleted;
            }

            public List<CategoryView> GetAllCategories()
            {
            try
            {
                //var advanceSalaries = _context.AdvanceSalary.ToList();
                var categories = _context.Category.Where(x => x.IsActive == true).AsNoTracking().ToList();
                return _mapper.Map<List<Category>, List<CategoryView>>(categories);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Categories", e);
            }
        }

        public CategoryView GetById(int id)
        {
            try
            {
                var category = _context.Category.AsNoTracking().FirstOrDefault(x => x.CategoryID == id);
                return _mapper.Map<CategoryView>(category);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Category By Id", e);
            }
        }

        public async Task<CategoryView> UpdateCategory(CategoryView categoryView)
        {
            try
            {

                var category = _mapper.Map<Category>(categoryView);
                _context.ChangeTracker.Clear();
                _context.Category.Update(category);
                await _context.SaveChangesAsync();
                return _mapper.Map<CategoryView>(category);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Category", e);
            }
        }
    }
}
