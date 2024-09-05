using Microsoft.EntityFrameworkCore;
using TodoTask.Web.Data;
using TodoTask.Web.Data.Entity;
using TodoTask.Web.Models;

namespace TodoTask.Web.Repositories.Todos
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _dataContext;
        public TodoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private string GenerateActivitiesNo()
        {
            var lastTodo = _dataContext.Todos.OrderByDescending(t => t.Id).FirstOrDefault();
            var lastNumber = lastTodo != null ? int.Parse(lastTodo.ActivitiesNo.Substring(3)) : 0;
            var newNumber = lastNumber + 1;
            return $"AC-{newNumber:D4}";
        }
        public async Task<TodoModel> AddTodo(TodoModel todoModel)
        {
            string activitiesNo = GenerateActivitiesNo();

            var todo = new Todo
            {
                ActivitiesNo = activitiesNo,
                Subject = todoModel.Subject,
                Description = todoModel.Description,
                UserId = todoModel.UserId,
                Status = todoModel.Status,
                CreatedDate = DateTime.UtcNow,
            };

            _dataContext.Todos.Add(todo);

            await _dataContext.SaveChangesAsync();

            return new TodoModel
            {
                Id = todo.Id,
                ActivitiesNo = activitiesNo,
                Subject = todo.Subject,
                Description = todo.Description,
            };


        }

        public Task<int> UpdateTodo(TodoModel todoModel)
        {
            throw new NotImplementedException();
        }
    }
}
