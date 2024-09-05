using TodoTask.Web.Models;

namespace TodoTask.Web.Repositories.User
{
    public interface IUserRepository
    {
        public Task<UserModel> Login (string username, string password);
        public Task<UserAddModel> AddRegistration (UserAddModel userAddModel);
        public Task<List<UserModel>> GetUsers();
        public Task<int> UpdateUser(UserAddModel userAddModel);
        public Task<int> DeleteUser (int UserId);
    }
}
