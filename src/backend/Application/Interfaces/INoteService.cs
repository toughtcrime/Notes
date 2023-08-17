using Application.DTO;
using Application.Responses;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.Interfaces;

public interface INoteService
{
    Task<Responses.Response<Note>> AddNoteAsync(string username, NoteDTO note);
    Task<Response<Note>> DeleteNoteAsync(long Id);
    Task<Response<Note>> UpdateNoteAsync(long Id,NoteDTO dto);
    Task<Response<Note>> GetNoteAsync(long Id);
    Task<Response<IReadOnlyCollection<NoteDTO>>> GetAllNotesAsync(long UserId);
}
