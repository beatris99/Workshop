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
        new Owner {  Id = new System.Guid("833400e7-30cb-494b-887d-139d7a193451"), Name = "OwnerName1" },
        new Owner {  Id = new System.Guid("833400e7-30cb-494b-887d-139d7a193451"), Name = "OwnerName2" },
        new Owner {  Id = new System.Guid(), Name = "OwnerName3" },
        new Owner {  Id = new System.Guid(), Name = "OwnerName4"},
        new Owner {  Id = new System.Guid(), Name = "OwnerName5" }
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

    }
}
