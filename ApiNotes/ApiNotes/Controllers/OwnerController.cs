//using ApiNotes.Models;
//using ApiNotes.Services;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

//namespace ApiNotes.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class OwnerController : ControllerBase
//    {
//        IOwnerCollectionService _ownerCollectionService;

//        public OwnerController(IOwnerCollectionService ownerCollectionService)
//        {
//            _ownerCollectionService = ownerCollectionService;
//        }

//        //[HttpGet]

//        //public async Task<IActionResult> GetOwner()
//        //{

//        //    List<Owner> owner = await _ownerCollectionService.GetAll();
//        //    return Ok(owner);
//        //}

//        [HttpPost]
//        public async Task<IActionResult> CreateOwner([FromBody] Owner owner)
//        {
//            if (owner == null)
//            {
//                return BadRequest("Note cannot be null");
//            }


//            if (await _ownerCollectionService.Create(owner))
//            {
//                return CreatedAtRoute("GetByOwnerId", new { id = owner.Id.ToString() }, owner);
//            }
//            return NoContent();
//        }

//        [HttpGet("ownerId/{id}")]
//        public async Task<IActionResult> GetOwnerId(Guid id)
//        {
//            if (id == null)
//            {
//                return BadRequest();
//            }

//            var owner = await _ownerCollectionService.Get(id);

//            if (owner == null)
//            {
//                return NotFound();
//            }
//            return Ok(owner);

//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteOwner(Guid id)
//        {
//            bool removed = await _ownerCollectionService.Delete(id);

//            if (removed)
//            {
//                return NoContent();
//            }

//            return NotFound();
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] Owner ownerToUpdate)
//        {
//            if (ownerToUpdate == null)
//            {
//                return BadRequest("Note cannot be null");
//            }

//            if (await _ownerCollectionService.Update(id, ownerToUpdate))
//            {
//                return NoContent();
//            }

//            return BadRequest();
//        }
//    }
//}
