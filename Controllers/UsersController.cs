using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoTask.Web.Commands.User;
using TodoTask.Web.Models;
using TodoTask.Web.Queries.User;

namespace TodoTask.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
           _mediator = mediator;
        }

        [HttpPost("Registration")]
        public async Task<ResponseModel<UserAddModel>> Registration(UserAddModel userAddModel)
        {
            var result = await _mediator.Send(new CreateUserCommand(
                userAddModel.Name,
                userAddModel.Email,
                userAddModel.Password,
                userAddModel.RoleId));

            return new ResponseModel<UserAddModel>
            {
                IsSuccess = result != null,
                Data = result
            };
            
        }

        [HttpPost("Login")]
        public async Task<ResponseModel<UserModel>> GetUserByUsername([FromQuery]  string username, [FromQuery] string password)
        {
            var user = await _mediator.Send(new GetUserByUsername() { Username = username, Password = password });

            if (user!= null)
            {
                // store to session
                HttpContext.Session.SetInt32("UserId", user.UserId);
            }
            return new ResponseModel<UserModel>
            {
                IsSuccess = user != null,
                Data = user
            };
        }

        [HttpGet("GetUsers")]
        public async Task<ResponseModel<List<UserModel>>> GetUserList()
        {
            var getUsers = await _mediator.Send(new GetUserListQuery());

            return new ResponseModel<List<UserModel>>
            {
                IsSuccess = getUsers != null,
                Data = getUsers
            };
        }
    }
}
