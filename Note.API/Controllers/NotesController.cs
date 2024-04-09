using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Note.API.Core.Context;
using Note.API.Core.DTO;
using Note.API.Core.Entities;

namespace Note.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {


       
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;
        public NotesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //Create
        [HttpPost]
        [Route("create")]

        public async Task<IActionResult> CreateNote([FromBody]CreateNoteDto createNoteDto)
        {

            var newNote = new NoteEntity();

            _mapper.Map(createNoteDto, newNote);

            //use current date and time as createdAt value

            newNote.CreatedAt = DateTime.Now;           


            await _context.Notes.AddAsync(newNote);

            await _context.SaveChangesAsync();

            return Ok("Note saved");

        }



        //Read all
         [HttpGet]
        public async Task<IActionResult> GetNotes()
        {
            var notes = await _context.Notes.ToListAsync();

            var notesDto = _mapper.Map<List<GetNoteDto>>(notes);

            return Ok(notesDto);
        }

        //Read by id

        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<GetNoteDto>> GetNoteById([FromRoute] long id)

        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

            if (note == null)
            {
                return NotFound("Note not found");
            }

            var convertedNote = _mapper.Map<GetNoteDto>(note);
            return Ok(convertedNote);
        }

        //Update
        [HttpPut]
        [Route("edit/{id}")]
        public async Task<IActionResult> EditTicket([FromRoute] long id, [FromBody]UpdateNoteDto updateNoteDto)
        {
            var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

            if (note == null)
            {
                return NotFound("Note not found");
            }

            _mapper.Map(updateNoteDto, note);

            await _context.SaveChangesAsync();

            return Ok("Note updated");
        }


        [HttpDelete]
         [Route("delete/{id}")]

         public async Task<IActionResult> DeleteNoteById([FromRoute] long id)
         {
             var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);

             if (note == null)
             {
                 return NotFound("Note not found");
             }

             _context.Notes.Remove(note);

             await _context.SaveChangesAsync();

             return Ok("Note deleted");
         }
        

        

        //Delete
        
    }
}
