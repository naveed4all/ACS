using ACS.ViewModels;
using ACS.ViewModels.UserModel;

namespace ACS.Services.Interfaces
{
    public interface IPermissionService
    {
        PermissionView GetById(int id);
        List<PermissionView> GetAll();
        Task<bool> DeletePermission(int id);
        Task<PermissionView> AddPermission(PermissionView PermissionView);
        Task<PermissionView> UpdatePermission(PermissionView PermissionView);
    }
}
