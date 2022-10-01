using EFCoreRelationshipsNET6.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsNET6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly DataContext _context;

        public WeaponController(DataContext context)
        {
            _context = context;
        }

        // identity id still increase even add fail (use "transaction" to prevent this)
        [HttpPost]
        public async Task<ActionResult<Character>> AddWeapon(AddWeaponDTO request)
        {
            var character = await _context.Characters.FindAsync(request.CharacterId);
            if (character == null)
                return NotFound();

            var newWeapon = new Weapon
            {
                Name = request.Name,
                Damage = request.Damage,
                Character = character
            };

            _context.Weapons.Add(newWeapon);
            await _context.SaveChangesAsync();

            return Created("", character);
        }
    }
}
