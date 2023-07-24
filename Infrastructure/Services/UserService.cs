using Application.Services;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;
using Presentation.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService
    {
        private readonly MainDbContext _context;

        public UserService(MainDbContext context)
        {

            _context = context;
        }

        public async Task<OneOf<User, HttpStatusCode>> GetUserById(long Id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);

            return user is not null ? user : HttpStatusCode.NotFound;
        }

        public async Task<OneOf<User,HttpStatusCode>> GetUserByUserName(string Username)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Username == Username);

            return user is not null ? user : HttpStatusCode.NotFound;
        }

        public async Task RegisterUser(RegisterRequest request)
        {

            //TODO: Implement user registration
        }
    }
}
