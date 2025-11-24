using DataLayer.Models.User;

namespace DataLayer.Interfaces.User
{
    public interface IUserRegisterRepository
    {
        public Task<UserModel> RegisterUserTask(UserModel newUser);

        public Task<bool> DoesEmailExists(string email);

    }
}
