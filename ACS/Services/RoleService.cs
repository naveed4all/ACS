using ACS.AppDBContext;
using ACS.Models.User_Model;
using ACS.Services.Interfaces;
using ACS.ViewModels.UserModel;
using AutoMapper;
using System.Collections.Generic;

namespace ACS.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public RoleService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoleView> AddRole(RoleView roleView)
        {
            try
            {
                var role = _mapper.Map<Role>(roleView);
                _context.Role.Add(role);
                await _context.SaveChangesAsync();
                return _mapper.Map<RoleView>(role);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Role", e);
            }
        }

        public async Task<bool>  DeleteRole(int id)
        {
            var isDeleted = false;
            try
            {
                var role = _context.Role.FirstOrDefault(x => x.RoleID == id);
                if (role == null)
                {
                    return true;
                }
                _context.Role.Remove(role);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting Role", e);
            }
            return isDeleted;
        }

        public List<RoleView> GetAll()
        {
            try
            {
                var roles = _context.Role.ToList();
                return _mapper.Map<List<Role>, List<RoleView>>(roles);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Roles", e);
            }
        }

        public RoleView GetById(int id)
        {
            try
            {
                var role = _context.Role.FirstOrDefault(x => x.RoleID == id);
                return _mapper.Map<RoleView>(role);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting Role By Id", e);
            }
        }

        public async Task<RoleView> UpdateRole(RoleView roleView)
        {
            try
            {
                var role = _mapper.Map<Role>(roleView);
                _context.Role.Update(role);
                await _context.SaveChangesAsync();
                return _mapper.Map<RoleView>(role);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating Role", e);
            }
        }
    }
}
