﻿using Application.Services;
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
using Application.Requests;
using System.Diagnostics;
using System.Web.Http.ModelBinding;
using Application.Responses;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly MainDbContext _context;
        private readonly UserMapping _mapping;
        private readonly IJwtService _jwtService;
        public UserService(MainDbContext context,
                           UserMapping mapping,
                           IJwtService jwtService)
        {
            _context = context;
            _mapping = mapping;
            _jwtService = jwtService;
        }

        public async Task<OneOf<User, HttpStatusCode>> GetUserByIdAsync(long Id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);

            return user is not null ? user : HttpStatusCode.NotFound;
        }

        public async Task<bool> isUserExists(string UsernameOrEmail)
        {
            var byName = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Username == UsernameOrEmail);
            if (byName != null)
            {
                return true;
            }
            var byEmail = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == UsernameOrEmail);
            return byEmail != null ? true : false;
        }

        public async Task<Response<User>> GetUserByUserNameAsync(string Username)
        {
            User? user = await _context.Users.Include(x => x.Notes)
                                             .FirstOrDefaultAsync(x => x.Username == Username);

            return user is not null ? new Response<User> { StatusCode = HttpStatusCode.Found, Data = user}
                : new Response<User>
            {
                Data = user,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessage = $"User with given username {Username} was not found"
            };
        }

        public async Task<OneOf<User,HttpStatusCode>> RegisterAsync(RegisterRequest request)
        {

            var user = _mapping.RegisterRequestToUser(request);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user is not null ? user : HttpStatusCode.Created;
        }


        public async Task<Response<string>> LoginAsync(LoginRequest request)
        {
            var userResponse = await GetUserByUserNameAsync(request.UsernameOrEmail);
            string jwtToken = string.Empty;
            if(userResponse.StatusCode == HttpStatusCode.Found)
            {
                var isPasswordMatching = _jwtService.VerifyPassword(request.Password, userResponse.Data.HashedPassword);
                jwtToken = _jwtService.GenerateJwtToken(userResponse.Data);

                return new Response<string>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Data = "Wrong username or password"
                };
            }
            return new Response<string>
            {
                StatusCode = HttpStatusCode.Created,
                Data = jwtToken
            };
        }
    }
}