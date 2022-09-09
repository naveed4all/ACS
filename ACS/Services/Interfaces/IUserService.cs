using ACS.ViewModels.UserModel;

namespace ACS.Services.Interfaces
{
    public interface IUserService
    {
        UserView GetById(int id);
        List<UserView> GetAll(int id);
        Task<bool> DeleteUser(int id);
        Task<UserView> AddUser(UserView UserView);
        Task<UserView> UpdateUser(UserView UserView);
        Task<bool> Login(string email, string hashedPassword);
    }
}
