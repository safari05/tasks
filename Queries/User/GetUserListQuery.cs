using MediatR;
using TodoTask.Web.Models;

namespace TodoTask.Web.Queries.User
{
    public class GetUserListQuery : IRequest<List<UserModel>>
    {
    }
}
