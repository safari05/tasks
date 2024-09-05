using Microsoft.EntityFrameworkCore;
using TodoTask.Web.Data;
using TodoTask.Web.Models;
using TodoTask.Web.Data.Entity;

namespace TodoTask.Web.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<UserAddModel> AddRegistration(UserAddModel userAddModel)
        {
            var user = new Data.Entity.User
            {
                Name = userAddModel.Name,
                Email = userAddModel.Email,
                Password = userAddModel.Password, // Consider hashing passwords
                RoleId = userAddModel.RoleId,
                CreatedBy = "System", // Or set appropriately
                CreatedDate = DateTime.UtcNow
            };


            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return new UserAddModel
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
            };
        }

        public Task<int> DeleteUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var users = await _dataContext.Users
                .Include(u => u.Role)  // Include related Role data
                .ToListAsync();

            // Map User entities to UserModel
            var listUser = users.Select(user => new UserModel
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                RoleName = user.Role.RoleName 
            }).ToList();

            return listUser;
        }

        public async Task<UserModel> Login(string username, string password)
        {
            var getUser = await _dataContext.Users
                .Include(u => u.Role)
                .Where(t => t.Name.ToLower() == username.ToLower() 
                        || t.Email.ToLower() == username)
                .Where (t => t.Password.ToLower() == password.ToLower())
                .FirstOrDefaultAsync();

           
            if (getUser == null)
            {
                return null;
            }

            var model = new UserModel
            {
                UserId = getUser.UserId,
                Name = getUser.Name,
                Email = getUser.Email,
                RoleName = getUser.Role.RoleName,
            };

            return model;
        }

        public Task<int> UpdateUser(UserAddModel userAddModel)
        {
            throw new NotImplementedException();
        }
    }
}
