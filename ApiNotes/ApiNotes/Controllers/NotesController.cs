using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNotes.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private static List<Notes> _notes = new List<Notes> { 
        new Notes { Id = Guid.NewGuid(), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "First Note", Description = "First Note Description" },
        new Notes { Id =new Guid("00000000-0000-0000-0000-000000000002"), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Second Note", Description = "Second Note Description" },
        new Notes { Id = new Guid("00000000-0000-0000-0000-000000000003"), CategoryId = "1", OwnerId = Guid.NewGuid(), Title = "Third Note", Description = "Third Note Description" },
        new Notes { Id = new Guid("00000000-0000-0000-0000-000000000004"), CategoryId = "1", OwnerId = new Guid("90874515-ed0e-4758-b396-0e38051eaca4"), Title = "Fourth Note", Description = "Fourth Note Description" },
        new Notes { Id = new Guid("00000000-0000-0000-0000-000000000005"), CategoryId = "1", OwnerId =new Guid("90874515-ed0e-4758-b396-0e38051eaca4"), Title = "Fifth Note", Description = "Fifth Note Description" }
        };




        public NotesController() { }


        [HttpGet]
        public IActionResult GetNotes()
        {

            return Ok(_notes);
        }

        [HttpPost]
        public IActionResult CreateNotes([FromBody] Notes note)
        {
            if (note == null)
            {
                return BadRequest("Note cannot be null");
            }
            _notes.Add(note);
            return CreatedAtRoute("GetNotes", new { id = note.Id.ToString() }, note);
            return Ok();
        }

        [HttpGet("ownerId/{id}")]
        public IActionResult GetByOwnerId(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            List<Notes> notes = _notes.FindAll(note => note.OwnerId == id);

            if (!notes.Any())
            {
                return NotFound();
            }
            return Ok(notes);

        }

        [HttpGet("/id")]
        public IActionResult GetByNoteId(Guid idNote)
        {
            if (idNote == null)
            {
                return BadRequest();
            }
            List<Notes> notes = _notes.FindAll(note => note.Id == idNote);

            if (!notes.Any())
            {
                return NotFound();
            }
            return Ok(notes);
        }

        // <summary>
        // 
        // </summary>
        // <response code = "400" > Bad request</response>
        // <response code = "404" > Not found</response>
        // <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateNote(Guid id, [FromBody] Notes noteToUpdate)
        {
            if (noteToUpdate == null)
            {
                return BadRequest("Note cannot be null");
            }
            var index = _notes.FindIndex(note => note.Id == id);

            if (index == -1)
            {
                return NotFound();
            }

            noteToUpdate.Id = _notes[index].Id;

            _notes[index] = noteToUpdate;

            return Ok(_notes[index]);
        }

        [HttpPatch("{id}/title")]
        public IActionResult UpdateTitle(Guid id, [FromBody] string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return BadRequest("The string cannot be null");
            }

            var index = _notes.FindIndex(note => note.Id == id);

            if (index == -1)
            {
                return NotFound();
            }

            _notes[index].Title = title;

            return Ok(_notes[index]);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            var index = _notes.FindIndex(notes => notes.Id == id);

            if (index == -1)
            {
                return NotFound();
            }

            _notes.RemoveAt(index);

            return NoContent();
        }



        /// <summary>
        /// HW
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        //[HttpGet("idOwner /{id}")]
        //public IActionResult GetWithParams(Guid id, Guid ownerId)
        //{
        //    return Ok($"id: {id} id2: {ownerId} ");
        //}

        /// <summary>
        /// Delete note based on OwnerId and note id.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("/noteId")]
        public IActionResult DeleteNoteByIdAndOwnerId(Guid noteId,  Guid ownerId)
        {
            var index = _notes.FindIndex(note => note.Id == noteId && note.OwnerId == ownerId);
            
            if (index == -1)
            {
                return NotFound();
            }

            _notes.RemoveAt(index);

            return NoContent();
        }

        /// <summary>
        /// Delete all notes of a given OwnerId.
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        [HttpDelete("ownerId")]
        public IActionResult DeleteOwnerId(Guid ownerId)
        {
            if(ownerId == null)
            {
                return BadRequest();
            }

            var index = _notes.FindIndex(note => note.OwnerId == ownerId);

            if (index == -1)
            {
                return NotFound();
            }
           
            _notes.RemoveAll(x => x.OwnerId == ownerId);
           
            return NoContent();
        }

        /// <summary>
        /// Update note based on OwnerId and note id. (find resource based on Id and OwnerId)
        /// </summary>
        /// <param name="noteId"></param>
        /// <param name="ownerId"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpPatch("")]
        public IActionResult UpdateTitleByIdAndOwnerId(Guid noteId, Guid ownerId, [FromBody] string title)
        {
            if (string.IsNullOrEmpty(title) || noteId == null || ownerId ==null)
            {
                return BadRequest();
            }
            
            var index = _notes.FindIndex(note => note.Id == noteId && note.OwnerId == ownerId);
            

            if (index == -1 )
            {
                return NotFound();
            }

            _notes[index].Title = title;
           

            return Ok(_notes[index]);
        }

    }
}
