using MediatR;
using TodoTask.Web.Models;
using TodoTask.Web.Queries.User;
using TodoTask.Web.Repositories.User;

namespace TodoTask.Web.Handler.User
{
    public class GetUserListHandler : IRequestHandler<GetUserListQuery, List<UserModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserListHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserModel>> Handle(GetUserListQuery query, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsers();
        }
    }
}
