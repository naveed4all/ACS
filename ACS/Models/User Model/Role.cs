namespace ACS.Models.User_Model
{
    public class Role
    {
        public int RoleID { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
