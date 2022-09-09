using ACS.ViewModels;

namespace ACS.Services.Interfaces
{
    public interface IRolePermissionService
    {
        RolePermissionView GetById(int id);
        List<RolePermissionView> GetAll();
        Task<bool> DeleteRolePermission(int id);
        Task<RolePermissionView> AddRolePermission(RolePermissionView RolePermissionView);
        Task<RolePermissionView> UpdateRolePermission(RolePermissionView RolePermissionView);
        Task<RolePermDTOView> AddRolePermissions(RolePermDTOView RolePermissionsView);
    }
}
