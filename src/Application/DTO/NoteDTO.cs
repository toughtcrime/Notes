using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public record NoteDTO
    {
        public required string Title { get; init; }
        public required string Content { get; init; }
    }
}
