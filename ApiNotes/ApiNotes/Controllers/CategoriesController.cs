using ApiNotes.Models;
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

        static List<Category> _categories = new List<Category> {
        new Category {  Id = "1", Name = "To Do" },
        new Category {  Id = "2", Name = "Done" },
        new Category {  Id = "3", Name = "Doing" },
       
        };
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
        public IActionResult GetCategory()
        {
            return Ok(_categories);
        }

        /// <summary>
        /// Returns the filter collection.
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <returns></returns>
        [HttpPost("")]
        public IActionResult Post([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Note cannot be null");
            }
            _categories.Add(category);
            return CreatedAtRoute("GetNotes", new { id = category.Id.ToString() }, category);
            //return Ok();
        }

        /// <summary>
        /// Returns the note collection.
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {

            if (!id.Any())
            {
                return NotFound();
            }
          //  _categories.Remove();
            return Ok();
        }
    }
}