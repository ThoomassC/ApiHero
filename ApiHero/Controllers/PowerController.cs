using ApiHero.Models;
using ApiHero.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerController : ControllerBase
    {
        private readonly IPowerService _powerService;

        public PowerController(IPowerService powerService)
        {
            _powerService = powerService;
        }

        // GET: api/power
        [HttpGet]
        public async Task<IEnumerable<Power>> GetPowers()
        {
            return await _powerService.GetPowersService();
        }

        // GET: api/power/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Power>> GetPower(int id)
        {
            var power = await _powerService.GetPowerService(id);

            if (power == null)
            {
                return NotFound();
            }

            return power;
        }

        // POST: api/power
        [HttpPost]
        public async Task<ActionResult<Power>> PostPower(Power power)
        {
            await _powerService.PostPowerService(power);

            return CreatedAtAction(nameof(GetPower), new { id = power.Id }, power);
        }

        // PUT: api/power/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPower(int id, Power power)
        {
            if (id != power.Id)
            {
                return BadRequest();
            }

            if (!await _powerService.PowerExistsService(id))
            {
                return NotFound();
            }

            await _powerService.PutPowerService(id, power);

            return NoContent();
        }

        // DELETE: api/power/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePower(int id)
        {
            if (!await _powerService.PowerExistsService(id))
            {
                return NotFound();
            }

            await _powerService.DeletePowerService(id);

            return NoContent();
        }

        private async Task<bool> PowerExists(int id)
        {
            return await _powerService.PowerExistsService(id);
        }
    }
}
