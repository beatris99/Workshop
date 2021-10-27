using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {

        List<string> myList = new List<string> { "To do", "Done", "Doing" };

        public CategoriesController() { }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <returns></returns>

        //[HttpGet("{id}")]
        //[Route("/categories")]
        //public IActionResult GetWithParams(string id, string id2, string id3)
        //{
        //    return Ok($"id: {id} id2: {id2} id3: {id3}");
        //}

        /// <summary>
        /// Returns a list of categories.
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(myList);
        }

        /// <summary>
        /// Returns the filter collection.
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <returns></returns>
        [HttpPost("")]
        public IActionResult Post([FromBody] string bodyContent)
        {
            myList.Add(bodyContent);
            return Created(" ",bodyContent);
        }

        /// <summary>
        /// Returns the note collection.
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            myList.Remove(id);
            return NoContent();
        }
    }
}