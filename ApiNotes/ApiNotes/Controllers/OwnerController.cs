using ApiNotes.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace ApiNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : ControllerBase
    {
        static List<Owner> _owner = new List<Owner> {
        new Owner {  Id = Guid.NewGuid(), Name = "OwnerName1" },
        new Owner {  Id = Guid.NewGuid(), Name = "OwnerName2" },
        new Owner {  Id = Guid.NewGuid(), Name = "OwnerName3" },
        new Owner {  Id = Guid.NewGuid(), Name = "OwnerName4"},
        new Owner {  Id = Guid.NewGuid(), Name = "OwnerName5" }
        };

        public OwnerController() { }

        [HttpGet("/owner")]
        
        public IActionResult GetOwner()
        {
            return Ok(_owner);
        }

        [HttpPost("/owner")]
        public IActionResult CreateOwner([FromBody] Owner owner)
        {
            if (owner == null)
            {
                return BadRequest("Owner cannot be null");
            }
            _owner.Add(owner);

            return CreatedAtRoute("GetOwner", new {idOwner = owner.Id }, owner);
        }

        [HttpGet("owner/{idOwner}", Name = "GetOwner")]
        public IActionResult GetByOwnerId(Guid idOwner)
        {

            List<Owner> owner = _owner.FindAll(owner => owner.Id == idOwner);
            return Ok(owner);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="400">Bad request</response>
        /// <returns></returns>
        [HttpDelete("{idOwner}")]
        public IActionResult DeleteOwner(Guid idOwner)
        {
            var index = _owner.FindIndex(owner => owner.Id == idOwner);

            if (index == -1)
            {
                return NotFound();
            }

            _owner.RemoveAt(index);

            return NoContent();
        }

        [HttpPatch("{idOwner}")]
        public IActionResult UpdateOwner(Guid idOwner, [FromBody] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("The string cannot be null");
            }

            var index = _owner.FindIndex(owner => owner.Id == idOwner);

            if (index == -1)
            {
                return NotFound();
            }

            _owner[index].Name = name;

            return Ok(_owner[index]);
        }
    }
}
