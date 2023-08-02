using Domain.Models;

namespace Application.Services
{
    public interface IJwtService
    {
        string GenerateJwtToken(User user);
        string HashPassowrd(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
