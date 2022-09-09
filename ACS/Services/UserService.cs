using ACS.AppDBContext;
using ACS.Models.User_Model;
using ACS.Services.Interfaces;
using ACS.ViewModels.UserModel;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace ACS.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(AppDbContext context,IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserView> AddUser(UserView userView)
        {
            try
            {
                var user = _mapper.Map<User>(userView);
                _context.User.Add(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserView>(user);
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding User", e);
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            var isDeleted = false;
            try
            {
                var user = _context.User.FirstOrDefault(x => x.UserID == id);
                if(user == null)
                {
                    return true;
                }
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }
            catch (Exception e)
            {
                throw new Exception("Error Deleting User", e);
            }
            return isDeleted;
        }

        public List<UserView> GetAll(int id)
        {
            try
            {
                var users = _context.User.ToList();
                return _mapper.Map<List<User>,List<UserView>>(users);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting User", e);
            }
        }

        public UserView GetById(int id)
        {
            try
            {
                var user = _context.User.FirstOrDefault(x => x.UserID == id);
                return _mapper.Map<UserView>(user);
            }
            catch (Exception e)
            {
                throw new Exception("Error Getting User", e);
            }
        }

        public async Task<UserView> UpdateUser(UserView userView)
        {
            try
            {
                var user = _mapper.Map<User>(userView);
                _context.User.Update(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserView>(user);
            }
            catch (Exception e)
            {
                throw new Exception("Error Updating User", e);
            }
        }

        public async Task<bool> Login(string email, string hashedPassword)
        {
            try
            {
                var user = _context.User.FirstOrDefault(x => x.Email == email && x.Password == hashedPassword);
                if (user != null)
                {
                    var claims = new List<Claim> {
                        new Claim("Email", user.Email),
                        new Claim("Password", user.Password)
                    };
                    var userIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    var userPrincipal = new ClaimsPrincipal(userIdentity);
                    //await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);
                    //_httpContextAccessor.HttpContext.Session.SetString("UserEmail",email);
                    //_httpContextAccessor.HttpContext.Session.SetString("UserId",user.UserID.ToString());
                    //_httpContextAccessor.HttpContext.Session.SetString("UserName",user.FullName);
                    //_httpContextAccessor.HttpContext.Session.SetString("UserRole",user.RoleID.ToString());

                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error Logging in User", e);
            }
            return false;
        }
    }
}
