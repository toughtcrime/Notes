using Domain.Models;

namespace Application.Services
{
    public interface IUserService
    {
        User? GetUserById(long id);
        User? Register();
        User? Login();
    }
}
