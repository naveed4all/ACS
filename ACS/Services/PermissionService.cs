using ACS.AppDBContext;
using ACS.Models;
using ACS.Models.User_Model;
using ACS.Services.Interfaces;
using ACS.ViewModels;
using ACS.ViewModels.UserModel;
using AutoMapper;
using Microsoft.AspNetCore.Components;

namespace ACS.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public PermissionService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<PermissionView> AddPermission(PermissionView PermView)
        {
            try
            {
                var permission = _mapper.Map<Permission>(PermView);
                
                _context.Permission.Add(permission);
                await _context.SaveChangesAsync();
                return _mapper.Map<PermissionView>(permission);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Permission", e);
            }
;
        }

        public async Task<bool> DeletePermission(int id)
        {
            var isDeleted = false;
            try
            {
                var permission = _context.Permission.FirstOrDefault(x => x.PermissionId == id);
                if (permission == null)
                {
                    return true;
                }
                _context.Permission.Remove(permission);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Permission", e);
            }
            return isDeleted;
        }

        public List<PermissionView> GetAll()
        {
            try
            {
                var permissions = _context.Permission.ToList();
                return _mapper.Map<List<Permission>, List<PermissionView>>(permissions);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Permissions", e);
            }
        }

        public PermissionView GetById(int id)
        {
            try
            {
                var permission = _context.Permission.FirstOrDefault(x => x.PermissionId == id);
                return _mapper.Map<PermissionView>(permission);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Permission By Id", e);
            }
        }

        public async Task<PermissionView> UpdatePermission(PermissionView permissionView)
        {
            try
            {
                var permission = _mapper.Map<Permission>(permissionView);
                _context.Permission.Update(permission);
                await _context.SaveChangesAsync();
                return _mapper.Map<PermissionView>(permission);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Permission", e);
            }
        }
    }
}
