using Application.Services;
using Domain.Models;
using Infrastructure.Data;
using Application.Mappings;
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
namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly MainDbContext _context;
        private readonly UserMapping _mapping;
        public UserService(MainDbContext context, UserMapping mapping)
        {
            _context = context;
            _mapping = mapping;
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

        public async Task<OneOf<User,HttpStatusCode>> Register(RegisterRequest request)
        {

            var user = _mapping.RegisterMap(request);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user is not null ? user : HttpStatusCode.Created;
        }

        public Task<OneOf<User, HttpStatusCode>> Login(RegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
