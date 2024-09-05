using TodoTask.Web.Models;

namespace TodoTask.Web.Repositories.Todos
{
    public interface ITodoRepository
    {
        public Task<TodoModel> AddTodo(TodoModel todoModel);
        public Task<int> UpdateTodo(TodoModel todoModel);
    }
}
