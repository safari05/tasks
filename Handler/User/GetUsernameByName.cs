using MediatR;
using TodoTask.Web.Models;
using TodoTask.Web.Queries.User;
using TodoTask.Web.Repositories.User;

namespace TodoTask.Web.Handler.User
{
    public class GetUsernameByName : IRequestHandler<GetUserByUsername, UserModel>
    {
        private readonly IUserRepository _userRepository;
        public GetUsernameByName(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> Handle(GetUserByUsername query, CancellationToken cancellationToken)
        {
            return await _userRepository.Login(query.Username, query.Password);
        }
    }
}
