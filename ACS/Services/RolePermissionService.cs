using ACS.AppDBContext;
using ACS.Models;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACS.Services
{
    public class RolePermissionService : IRolePermissionService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public RolePermissionService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RolePermissionView> AddRolePermission(RolePermissionView RolePermView)
        {
            try
            {
                var rolepermission = _mapper.Map<RolePermission>(RolePermView);
                _context.RolePermission.Add(rolepermission);
                await _context.SaveChangesAsync();
                return _mapper.Map<RolePermissionView>(rolepermission);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Role Permission", e);
            };
        }

        

        public async Task<RolePermDTOView> AddRolePermissions(RolePermDTOView RolePermissionsView)
        {          
            try
            {
                var rolepermission = _mapper.Map<RolePermDTOView>(RolePermissionsView);

                var _roles = _context.RolePermission.Where(x => x.RoleId == RolePermissionsView.RoleId).ToList();

                foreach (var item in _roles)
                {
                    _context.RolePermission.Remove(item);
                    await _context.SaveChangesAsync();
                }

                foreach (var permission in RolePermissionsView.PermissionsID)
                {
                    var obj = _context.RolePermission.Add(new RolePermission()
                    {
                        RoleId = RolePermissionsView.RoleId,
                        PermissionId = permission,
                        CreatedDateTime = DateTime.Now,
                        CreatedByUserID = RolePermissionsView.CreatedByUserID
                    });
                }

              
                await _context.SaveChangesAsync();
                return _mapper.Map<RolePermDTOView>(rolepermission);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Role Permissions", e);

            }
            
        }

        public async Task<bool> DeleteRolePermission(int id)
        {
            var isDeleted = false;
            try
            {
                var rolepermission = _context.RolePermission.FirstOrDefault(x => x.RolePermissionId == id);
                if (rolepermission == null)
                {
                    return true;
                }
                _context.RolePermission.Remove(rolepermission);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Role Permission", e);
            }
            return isDeleted;
        }

        public List<RolePermissionView> GetAll()
        {
            try
            {
                var rolepermissions = _context.RolePermission.ToList();
                return _mapper.Map<List<RolePermission>, List<RolePermissionView>>(rolepermissions);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Role Permissions", e);
            }
        }

        public RolePermissionView GetById(int id)
        {
            try
            {
                var rolepermission = _context.RolePermission.FirstOrDefault(x => x.RolePermissionId == id);
                return _mapper.Map<RolePermissionView>(rolepermission);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Role Permission By Id", e);
            }
        }

        public async Task<RolePermissionView> UpdateRolePermission(RolePermissionView rolepermissionView)
        {
            try
            {
                var rolepermission = _mapper.Map<RolePermission>(rolepermissionView);
                _context.RolePermission.Update(rolepermission);
                await _context.SaveChangesAsync();
                return _mapper.Map<RolePermissionView>(rolepermission);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Role Permission", e);
            }
        }



        
    }
}
