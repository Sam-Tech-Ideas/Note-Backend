using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Note.API.Core.DTO;
using Note.API.Core.Entities;

namespace Note.API.Core.Automapper
{
    public class AutomapperConfigProfile : AutoMapper.Profile
    {

        public AutomapperConfigProfile()
        {
        CreateMap<CreateNoteDto, NoteEntity>();
        CreateMap<NoteEntity, GetNoteDto>();
        CreateMap<UpdateNoteDto, NoteEntity>();
        }

    }

    
}
