using EFCoreRelationshipsNET6.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreRelationshipsNET6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly DataContext _context;

        public SkillController(DataContext context)
        {
            _context = context;
        }

        // to a a skill to the skill pool, use the DTO(also apply for the weapon)
        [HttpPost]
        public async Task<ActionResult<Character>> AddCharacterSkill(AddCharacterSkillDTO request)
        {
            // find character
            var character = await _context.Characters
                .Where(c => c.Id == request.CharacterId)
                .Include(c => c.Skills) // get to display skill (there is no include weapon so it will shown as null)
                .FirstOrDefaultAsync();
            if (character == null)
                return NotFound();
            // find skill
            var skill = await _context.Skills.FindAsync(request.SkillId);
            if (skill == null)
                return NotFound();

            character.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return Created("", character);
        }
    }
}
