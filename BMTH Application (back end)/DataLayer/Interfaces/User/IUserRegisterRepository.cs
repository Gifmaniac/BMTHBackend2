using DataLayer.Models.User;

namespace DataLayer.Interfaces.User
{
    public interface IUserRegisterRepository
    {
        public Task<UserRegisterModel> RegisterUserTask(UserRegisterModel newUser);

        public Task<bool> DoesEmailExists(string email);

    }
}
