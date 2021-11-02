using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNotes.Models;
using ApiNotes.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {

        INoteCollectionService _noteCollectionService;
        public NotesController(INoteCollectionService noteCollectionService)
        {
            _noteCollectionService = noteCollectionService;
        }


        [HttpGet]
        public async Task<IActionResult> GetNotes()
        {

            List<Note> notes = await _noteCollectionService.GetAll();
            return Ok(notes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotes([FromBody] Note note)
        {
            if (note == null)
            {
                return BadRequest("Note cannot be null");
            }


            if (await _noteCollectionService.Create(note))
            {
                return CreatedAtRoute("GetByNoteId", new { id = note.Id.ToString() }, note);
            }
            return NoContent();
        }

        [HttpGet("ownerId/{id}")]
        public async Task<IActionResult> GetByOwnerId(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var note = await _noteCollectionService.Get(id);

            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);

        }

        [HttpGet("/id", Name = "GetByNoteId")]
        public async Task<IActionResult> GetByNoteId(Guid idNote)
        {
            if (idNote == null)
            {
                return BadRequest();
            }
            var note = await _noteCollectionService.Get(idNote);

            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        // <summary>
        // 
        // </summary>
        // <response code = "400" > Bad request</response>
        // <response code = "404" > Not found</response>
        // <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(Guid id, [FromBody] Note noteToUpdate)
        {
            if (noteToUpdate == null)
            {
                return BadRequest("Note cannot be null");
            }

            if (await _noteCollectionService.Update(id, noteToUpdate))
            {
                return NoContent();
            }

            return BadRequest("Note update failed");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            bool removed = await _noteCollectionService.Delete(id);

            if (removed)
            {
                return NoContent();
            }

            return NotFound();
        }


    }
}
