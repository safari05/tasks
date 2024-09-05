using MediatR;
using TodoTask.Web.Models;

namespace TodoTask.Web.Commands.Todo
{
    public class CreateTodoCommand : IRequest<TodoModel>
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public  string Status { get; set; }
        public int UserId { get; set; }

        public CreateTodoCommand(string subject, string description, string status, int userId)
        {
            Subject = subject;
            Description = description;
            Status = status;
            UserId = userId;
        }
    }
}
