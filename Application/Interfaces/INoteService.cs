using Application.DTO;
using Domain.Models;

namespace Application.Interfaces;

public interface INoteService
{
    Task<Responses.Response<Note>> AddNote(string username, NoteDTO note);

}
