using MediatR;
using TodoTask.Web.Models;

namespace TodoTask.Web.Commands.User
{
    public class CreateUserCommand: IRequest<UserAddModel>
    {
        public string Name { get; set; }
        public string Password{ get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
        public DateTime CreatedAt { get; set; }

        public CreateUserCommand(string name,  string email, string password, int role)
        {
            Name = name;
            Password = password;
            Email = email;
            RoleID = role;
            CreatedAt = DateTime.Now;
        }

    }
}
