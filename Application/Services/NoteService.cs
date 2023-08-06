using Application.DTO;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class NoteService : INoteService
{
    private readonly MainDbContext _context;
    private readonly IUserService _userService;
    public NoteService(MainDbContext context, IUserService userService)
    {
        _context = context;
        _userService = userService;
    }

    public async Task<Response<Note>> AddNote(string username,NoteDTO note)
    {
        var result = await _userService.GetUserByUserNameAsync(username);
        if(result.IsT1)
        {
            //Returning http response
            return result.AsT1; 
        }
        var user = result.AsT0;
        var noteToAdd = new Note
        {
            Content = note.Content,
            Title = note.Title,
            Owner = user,
            OwnerId = user.Id
        };


        user.Notes.Add(noteToAdd);
        int saved = await _context.SaveChangesAsync();

        if(saved == 0)
        {
            return new Response<Note>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Data = noteToAdd,
                ErrorMessage = "Something gone wrong"
            };
        }
           
        return new Response<Note>
        {
            StatusCode = HttpStatusCode.Created,
            Data = noteToAdd,
            ErrorMessage = string.Empty
        };

    }
}
