using Application.DTO;
using Application.Interfaces;
using Application.Mappings;
using Application.Responses;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class NoteService : INoteService
{
    private readonly MainDbContext _context;
    private readonly IUserService _userService;
    private readonly NoteMapping _mapping;
    public NoteService(MainDbContext context, IUserService userService, NoteMapping mapping)
    {
        _context = context;
        _userService = userService;
        _mapping = mapping;
    }

    public async Task<Response<Note>> AddNoteAsync(string username,NoteDTO note)
    {
        var result = await _userService.GetUserByUserNameAsync(username);
        if(result.IsT1)
        {
            //Returning http response
            return result.AsT1; 
        }
        var user = result.AsT0;
        var noteToAdd = _mapping.MapToNote(note, user);


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
    public async Task<Response<Note>> DeleteNoteAsync(long Id)
    {
        var Note = _context.Notes.FirstOrDefault(x => x.Id == Id);
        _context.Notes.Remove(Note);
        var result = await _context.SaveChangesAsync();
        if(result == 0)
        {
            return new Response<Note>
            {
                StatusCode = HttpStatusCode.Conflict,
                Data = Note,
                ErrorMessage = "Deleting was not successfull"
            };
        }

        return new Response<Note>
        {
            StatusCode = HttpStatusCode.NoContent,
            Data = Note,
            ErrorMessage = "Deleting successfully completed"
        };
    }
    public async Task<Response<Note>> UpdateNoteAsync(long Id,NoteDTO dto)
    {
        var Note = await _context.Notes.FirstOrDefaultAsync(x => x.Id == Id);
        Note.Title = dto.Title;
        Note.Content = dto.Content;
        var result = await _context.SaveChangesAsync();
        if(result == 0)
        {
            return new Response<Note>
            {
                StatusCode = HttpStatusCode.Conflict,
                Data = Note,
                ErrorMessage = $"Entity with id: {Note.Id} was not updated for some reason"
            };
        }

        return new Response<Note>
        {
            StatusCode = HttpStatusCode.OK,
            Data = Note,
            ErrorMessage = $"Entity with id: {Note.Id} was successfully updated"
        };
    }
    public async Task<Response<Note>> GetNoteAsync(long Id)
    {
        var note = await _context.Notes.FirstOrDefaultAsync(x => x.Id == Id);
        if(note is null)
        {
            return new Response<Note>
            {
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessage = "Note is not exist!"
            };
        }
        return new Response<Note> { StatusCode = HttpStatusCode.OK, Data = note };
    }
    public async Task<Response<IReadOnlyCollection<NoteDTO>>> GetAllNotesAsync(long UserId)
    {
        var noteDtos = _context.Notes.AsNoTracking()
                                     .Where(x => x.OwnerId == UserId)
                                     .Select(x => new NoteDTO { Title = x.Title, Content = x.Content })
                                     .ToList()
                                     .AsReadOnly();

        if(noteDtos is null)
        {
            return new Response<IReadOnlyCollection<NoteDTO>>
            {
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessage = $"User was not found"
            };
        }

        return new Response<IReadOnlyCollection<NoteDTO>> { StatusCode = HttpStatusCode.OK, Data = noteDtos };
    }
}
