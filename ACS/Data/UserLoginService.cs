using ACS.Helpers;
using ACS.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ACS.Data
{
    public class UserLoginService
    {
        private readonly IUserService _userService;
        private Task<AuthenticationState> authStateTask { get; set; }
        protected string username { get; set; }
        protected string password { get; set; }
        public UserLoginService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Login(string email, string password)
        {
            var isValid = false;
            try
            {
                var hashedPassword = password.HashWithSalt();
                isValid = await _userService.Login(email, hashedPassword);

                var claims = new List<Claim>
            {
                //new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Email, email),
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //await HttpContext.SignInAsync(
                //    CookieAuthenticationDefaults.AuthenticationScheme,
                //    new ClaimsPrincipal(claimsIdentity));


            }
            catch (Exception e)
            {
                //throw new Exception("Error login unsuccessful");
            }
            return isValid;
        }

    }
}
