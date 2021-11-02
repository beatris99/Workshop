using ApiNotes.Models;
using ApiNotes.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiNotes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : ControllerBase
    {
        IOwnerCollectionService _ownerCollectionService;

        public OwnerController(IOwnerCollectionService ownerCollectionService)
        {
            _ownerCollectionService = ownerCollectionService;
        }

        //[HttpGet]

        //public async Task<IActionResult> GetOwner()
        //{

        //    List<Owner> owner = await _ownerCollectionService.GetAll();
        //    return Ok(owner);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] Owner owner)
        {
            if (owner == null)
            {
                return BadRequest("Note cannot be null");
            }


            if (await _ownerCollectionService.Create(owner))
            {
                return CreatedAtRoute("GetByOwnerId", new { id = owner.Id.ToString() }, owner);
            }
            return NoContent();
        }

        [HttpGet("ownerId/{id}")]
        public async Task<IActionResult> GetOwnerId(Guid id) // Atentie putin mai mult la naming-uri
                                                             // Trebuie sa te gandesti ce iti returneaza metoda asta si ce input primesti
        {
            if (id == null)
            {
                return BadRequest();
            }

            var owner = await _ownerCollectionService.Get(id);

            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(Guid id)
        {

            //ce se intampla aici daca id este null?

            bool removed = await _ownerCollectionService.Delete(id);

            if (removed)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(Guid id, [FromBody] Owner ownerToUpdate)
        {
            // id null?

            if (ownerToUpdate == null)
            {
                return BadRequest("Note cannot be null"); // Note?
            }

            if (await _ownerCollectionService.Update(id, ownerToUpdate))
            {
                return NoContent();
            }

            return BadRequest();
        }

        // Delete all notes of a given OwnerId?
    }
}
