using EFCoreRelationshipsNET6.Model;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreRelationshipsNET6.Controllers
{
    // Not optimal!
    // no services and no authenthication - Fat Controller (change a bit from the video)
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly DataContext _context;

        public CharacterController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get(int userId)
        {
            var characters = await _context.Characters
                .Where(c => c.User.Id == userId)
                .Include(c => c.Weapon)// important
                .Include(c => c.Skills)// important
                .ToListAsync();
            return Ok(characters);
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> Create(CreateCharacterDTO request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return NotFound();

            var newCharacter = new Character
            {
                Name = request.Name,
                RpgClass = request.RpgClass,
                User = user
            };

            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            return await Get(newCharacter.UserId);
        }

    }
}
