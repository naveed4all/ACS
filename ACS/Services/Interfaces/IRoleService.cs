using ACS.ViewModels.UserModel;

namespace ACS.Services.Interfaces
{
    public interface IRoleService
    {
        RoleView GetById(int id);
        List<RoleView> GetAll();
        Task<bool> DeleteRole(int id);
        Task<RoleView> AddRole(RoleView RoleView);
        Task<RoleView> UpdateRole(RoleView RoleView);
    }
}
