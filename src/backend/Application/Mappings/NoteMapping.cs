using Application.DTO;
using Domain.Models;
using OneOf.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class NoteMapping
    {
        public Note MapToNote(NoteDTO dto, User user) => new Note
        {
            Content = dto.Content,
            Title = dto.Title,
            Owner = user,
            OwnerId = user.Id
        };
    }
}

