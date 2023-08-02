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
        public User RegisterMap(RegisterRequest request) => new User
        {
            Email = request.Email,
            Firstname = request.Firstname,
            Lastname = request.Lastname,
            BirthDay = request.BirthDay,
            HashedPassword = request.Password == request.RepeatPassword ?
                               BCrypt.Net.BCrypt.HashPassword(request.Password) : throw new Exception("Password is not matching"),
            Username = request.Username
        };
    }
}
