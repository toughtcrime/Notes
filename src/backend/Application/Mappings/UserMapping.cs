using Application.Requests;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Models;
using Microsoft.AspNetCore.Http.Features;
using Presentation.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class UserMapping
    {
        public User RegisterRequestToUser(RegisterRequest request) => new User
        {
            Email = request.Email,
            HashedPassword = request.Password == request.RepeatPassword ?
                               BCrypt.Net.BCrypt.HashPassword(request.Password) : throw new PasswordNotMatchingException(),
            Username = request.Username,
            Role = Roles.User
        };
    }
}
