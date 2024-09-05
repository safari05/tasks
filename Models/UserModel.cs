namespace TodoTask.Web.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class UserAddModel : UserModel
    {
        public string Password { get; set; }
    }

}
