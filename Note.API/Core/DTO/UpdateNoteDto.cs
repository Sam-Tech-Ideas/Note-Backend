using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.API.Core.DTO
{
    public class UpdateNoteDto
    {
        public string Title { get; set; }

        public string Text { get; set; }
    }
}
