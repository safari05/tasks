using MediatR;
using TodoTask.Web.Commands.User;
using TodoTask.Web.Models;
using TodoTask.Web.Repositories.User;

namespace TodoTask.Web.Handler.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserAddModel>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserAddModel> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var userAdd = new UserAddModel()
            {
                Name = command.Name,
                Email = command.Email,
                Password = command.Password,
                RoleId = command.RoleID,
            };

            var userModel = await _userRepository.AddRegistration(userAdd);
            if (userModel == null)
            {
                // Handle the case where userModel is null
                // For example, you could throw an exception or return a default value
                throw new InvalidOperationException("User creation failed.");
            }
            return userModel;
        }
    }
}
