using ACS.Models.User_Model;

namespace ACS.ViewModels.UserModel
{
    public class UserView
    {
        public int UserID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //public string FullName
        //{
        //    get
        //    {
        //        return FirstName + " " + LastName;
        //    }
        //}

        
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool RequiredPasswordChange { get; set; }

       
        public int? CreatedByUserID { get; set; }
        //public User CreatedByUser { get; set; }

        public int RoleID { get; set; }
        //public Role Role { get; set; }
    }
}
