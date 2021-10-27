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
        static List<Notes> _notes = new List<Notes> {
        new Notes { Id = new System.Guid(), CategoryId = "1", OwnerId = new System.Guid("833400e7-30cb-494b-887d-139d7a193451"), Title = "First Note", Description = "First Note Description" },
        new Notes { Id = new System.Guid(), CategoryId = "1", OwnerId = new System.Guid("833400e7-30cb-494b-887d-139d7a193451"), Title = "Second Note", Description = "Second Note Description" },
        new Notes { Id = new System.Guid(), CategoryId = "1", OwnerId = new System.Guid(), Title = "Third Note", Description = "Third Note Description" },
        new Notes { Id = new System.Guid(), CategoryId = "1", OwnerId = new System.Guid(), Title = "Fourth Note", Description = "Fourth Note Description" },
        new Notes { Id = new System.Guid("833400e7-30cb-494b-887d-139d7a193451"), CategoryId = "1", OwnerId = new System.Guid(), Title = "Fifth Note", Description = "Fifth Note Description" }
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
            //return Ok();
        }

        [HttpGet("ownerId/{id}")]
        public IActionResult GetByOwnerId(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            List<Notes> notes = _notes.FindAll(note => note.OwnerId == id);

            if(!notes.Any())
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

        

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <response code="400">Bad request</response>
        ///// <returns></returns>
        //[HttpGet]
        //public IActionResult GetName()
        //{
        //    return Ok("Note controller works");
        //}

        //    [HttpGet("{id}")]
        //    [Route("notes")]
        //    public IActionResult GetWithParams(string id, string id2, string id3)
        //    {
        //        return Ok($"id: {id} id2: {id2} id3: {id3}");
        //    }

        //    /// <summary>
        //    /// Returns a list of notes.
        //    /// </summary>
        //    /// <response code="400">Bad request</response>
        //    /// <returns></returns>
        //    [HttpGet("")]
        //    public IActionResult Get()
        //    {
        //        return Ok("From get");
        //    }

        //    /// <summary>
        //    /// Returns the note collection.
        //    /// </summary>
        //    /// <response code="400">Bad request</response>
        //    /// <returns></returns>
        //    [HttpPost("")]

        //    public IActionResult Post([FromBody] string bodyContent)
        //    {
        //        return Ok(bodyContent);
        //    }

        //  /// <summary>
        //    /// Returns the note collection.
        //    /// </summary>
        //    /// <response code="400">Bad request</response>
        //    /// <returns></returns>
        //   [HttpDelete("{id}")]
        //    public IActionResult Delete(string id)
        //    {
        //        return Ok();
        //    }
    }
}
