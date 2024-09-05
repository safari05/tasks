using MediatR;
using TodoTask.Web.Models;

namespace TodoTask.Web.Queries.User
{
    public class GetUserByUsername : IRequest<UserModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
