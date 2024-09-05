using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoTask.Web.Commands.Todo;
using TodoTask.Web.Models;

namespace TodoTask.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TodosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddTodos")]
        public async Task<ResponseModel<TodoModel>> AddTodo(TodoModel todoModel)
        {
            var result = await _mediator.Send(new CreateTodoCommand(
                    todoModel.Subject,
                    todoModel.Description,
                    todoModel.Status,
                    todoModel.UserId
                ));

            return new ResponseModel<TodoModel>
            {
                IsSuccess = result != null,
                Data = result
            };

        }

    }
}
