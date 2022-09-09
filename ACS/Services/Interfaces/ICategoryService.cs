using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface ICategoryService
    {
        //Fetch-All-Categories
        List<CategoryView> GetAllCategories();
        //Fetch-Category-By-ID
        CategoryView GetById(int id);

        //Add-Category
        Task<CategoryView> AddCategory(CategoryView categoryView);

        //Update-Category
        Task<CategoryView> UpdateCategory(CategoryView categoryView);
        //Delete-Category
        Task<bool> DeleteCategory(int id);
        
    }
}
