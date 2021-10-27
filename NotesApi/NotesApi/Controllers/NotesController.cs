using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NotesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        public NotesController() { }
        /// <summary>
        /// 
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetName()
        {
            return Ok("Note controller works");
        }

        [HttpGet("{id}")]
        [Route("/notes")]
        public IActionResult GetWithParams(string id, string id2, string id3)
        {
            return Ok($"id: {id} id2: {id2} id3: {id3}");
        }

        /// <summary>
        /// Returns a list of notes.
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok("From get");
        }

        /// <summary>
        /// Returns the note collection.
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <returns></returns>
        [HttpPost("")]

        public IActionResult Post([FromBody] string bodyContent)
        {
            return Ok(bodyContent);
        }

        /// <summary>
        /// Returns the note collection.
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok();
        }
    }
}
