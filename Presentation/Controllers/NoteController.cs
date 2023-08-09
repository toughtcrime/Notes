using Application.DTO;
using Application.Interfaces;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneOf.Types;
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


        [HttpGet("{Id:long}")]
        public async Task<IActionResult> GetNote(long Id)
        {
            var response = await _noteService.GetNoteAsync(Id);
            return response.StatusCode == HttpStatusCode.OK ? Ok() : NotFound();
        }

        [HttpPost("create/{username}")]
        public async Task<IActionResult> Create(string username,NoteDTO note)
        {
            var response = await _noteService.AddNoteAsync(username,note);
            return response.StatusCode == HttpStatusCode.Created ?
                Created($"Create/{username}", note) : BadRequest(response.ErrorMessage);
        }

        
        [HttpDelete("delete/{Id:long}")]
        //TODO: Implement jwt authorizing to authorize crud operations
        public async Task<IActionResult> Delete(long Id)
        {
            var response = await _noteService.DeleteNoteAsync(Id);

            return response.StatusCode == HttpStatusCode.NoContent ?
                           Ok() : Conflict(response.ErrorMessage);
        }
        [HttpPut("update/{Id:long}")]
        public async Task<IActionResult> Update(long Id,NoteDTO dto)
        {
            var response = await _noteService.UpdateNoteAsync(Id,dto);

            return response.StatusCode == HttpStatusCode.OK ?
                         Ok() : Conflict(response.ErrorMessage);
        }
    }
}
