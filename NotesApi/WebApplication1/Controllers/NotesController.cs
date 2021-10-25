using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NotesApi.Controllers
{
    [ApiController]
    [Route(template: "[controller]")]
    public class NotesController : ControllerBase
    {
        public NotesController() 
        { 

        }

        /// <summary>
        /// Returns a list of notes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Note controller works");
        }

    }
}
