using Application.Requests;
using Application.Responses;
using Domain.Models;
using OneOf;
using Presentation.Requests;
using System.Net;

namespace Application.Services
{
    public interface IUserService
    {
        Task<OneOf<User, HttpStatusCode>> GetUserByIdAsync(long Id);
        Task<Response<User>> GetUserByUserNameAsync(string Username);
        Task<OneOf<User, HttpStatusCode>> RegisterAsync(RegisterRequest request);
        Task<Response<string>> LoginAsync(LoginRequest request);

    }
}
