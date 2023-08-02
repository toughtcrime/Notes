using Domain.Models;
using OneOf;
using Presentation.Requests;
using System.Net;

namespace Application.Services
{
    public interface IUserService
    {
        Task<OneOf<User, HttpStatusCode>> GetUserById(long Id);
        Task<OneOf<User, HttpStatusCode>> GetUserByUserName(string Username);
        Task<OneOf<User, HttpStatusCode>> Register(RegisterRequest request);
        Task<OneOf<User, HttpStatusCode>> Login(RegisterRequest request);

    }
}
