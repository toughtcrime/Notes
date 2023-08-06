using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class NoteDTO
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
    }
}
