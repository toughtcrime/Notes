using Application.DTO;
using Application.Interfaces;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }


        [HttpPost("Create/{username}")]
        public async Task<IActionResult> Create(string username,NoteDTO note)
        {
            var response = await _noteService.AddNote(username,note);
            return response.StatusCode == HttpStatusCode.Created ?
                Created($"Create/{username}", note) : BadRequest(response.ErrorMessage);
        }

        
    }
}
