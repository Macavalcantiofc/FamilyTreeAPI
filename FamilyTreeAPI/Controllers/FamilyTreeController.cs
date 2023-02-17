using FamilyTreeAPI.Model;
using FamilyTreeAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTreeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyTreeController : ControllerBase
    {
        private readonly IFamilyTreeRepository _IFamilyTree;

        public FamilyTreeController(IFamilyTreeRepository FamilyTree)
        {
            _IFamilyTree = FamilyTree;
        }
        [HttpGet]
        public async Task<IEnumerable<FamilyTree>> familyTreesAsync()
        {
            return await _IFamilyTree.familyTreesAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyTree>> Get(int id)
        {
            return await _IFamilyTree.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<FamilyTree>> PostFamilyTree([FromBody] FamilyTree familyTree)
        {
            var newFamilyTree = await _IFamilyTree.Create(familyTree);
            return CreatedAtAction(nameof(Get), new { id = newFamilyTree.Id}, newFamilyTree);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var familyTree = await _IFamilyTree.Get(id);
            if (familyTree == null)
            {
                return NotFound();
            }
            else
            {
                await _IFamilyTree.Delete(familyTree.Id);
                return NoContent();
            }
        }
        [HttpPut]
        public async Task<ActionResult> PutFamily(int id,[FromBody] FamilyTree familyTree)
        {
            if (id != familyTree.Id)
                return BadRequest();
            
            await _IFamilyTree.Update(familyTree);
            return NoContent();
        }




    }
}
