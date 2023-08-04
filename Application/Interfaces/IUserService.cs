using Application.Requests;
using Application.Response;
using Domain.Models;
using OneOf;
using Presentation.Requests;
using System.Net;

namespace Application.Services
{
    public interface IUserService
    {
        Task<OneOf<User, HttpStatusCode>> GetUserByIdAsync(long Id);
        Task<OneOf<User, HttpStatusCode>> GetUserByUserNameAsync(string Username);
        Task<OneOf<User, HttpStatusCode>> RegisterAsync(RegisterRequest request);
        Task<Response<string>> LoginAsync(LoginRequest request);

    }
}
