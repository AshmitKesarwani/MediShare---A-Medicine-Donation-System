using MediShare.Models;

namespace MediShare.Services
{
    public interface IUserService
    {
        void Register(User user);
        User Validate(string email, string pwd);

        List<User> GetAll();

    }
}
