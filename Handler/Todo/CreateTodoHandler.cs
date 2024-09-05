using MediatR;
using TodoTask.Web.Commands.Todo;
using TodoTask.Web.Models;
using TodoTask.Web.Repositories.Todos;

namespace TodoTask.Web.Handler.Todo
{
    public class CreateTodoHandler : IRequestHandler<CreateTodoCommand, TodoModel>
    {
        private readonly ITodoRepository _todoRepository;
        public CreateTodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<TodoModel> Handle (CreateTodoCommand command, CancellationToken cancellationToken)
        {
            var todoAdd = new TodoModel()
            {
                Subject = command.Subject,
                Description = command.Description,
                Status = command.Status,
                UserId = command.UserId,
            };

            var todoAddModel = await _todoRepository.AddTodo(todoAdd);
            if (todoAddModel == null)
            {
                throw new InvalidOperationException("Todo Created failed.");
            }
            return todoAddModel;
        }
    }
}
