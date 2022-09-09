using ACS.Services.Interfaces;
using ACS.ViewModels;

namespace ACS.Data
{
    public class CategoryManagerService
    {
        private readonly ICategoryService _categoryService;
        public CategoryManagerService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        //Get-All-Categories

        public List<CategoryView> GetAllCategories()
        {
            var categories = _categoryService.GetAllCategories();
            return (categories);
        }

        //Add-Category

        public async Task<CategoryView> AddCategory(CategoryView categoryView)
        {
            categoryView.IsActive = true;
            categoryView.CreatedDateTime = DateTime.Now;
            categoryView.CreatedByUserID = 1;
            categoryView = await _categoryService.AddCategory(categoryView);

            return categoryView;

        }

        //Get-Category-By-ID
        public CategoryView GetById(int id)
        {
            return _categoryService.GetById(id);
        }

        

        //Update-Category
        public async Task<CategoryView> UpdateCategory(CategoryView categoryView)
        {
            categoryView.UpdatedDateTime = DateTime.Now;
            categoryView.UpdatedByUserID = 1;
            categoryView = await _categoryService.UpdateCategory(categoryView);

            return categoryView;

        }

        //Delete-Category

        public async Task<bool> DeleteCategoy(int id)
        {
            return await _categoryService.DeleteCategory(id);
        }
    }
}
