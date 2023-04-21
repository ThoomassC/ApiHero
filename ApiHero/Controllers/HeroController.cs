using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiHero.Models;
using ApiHero.Services;

namespace ApiHero.Controllers
{
    [Route("api/hero")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService _heroService;

        public HeroController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        // GET: api/hero
        [HttpGet]
        public async Task<IActionResult> GetHeroes()
        {
            var heroes = await _heroService.GetHeros();
            return Ok(heroes);
        }

        // GET: api/hero/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHero(int id)
        {
            var hero = await _heroService.GetHero(id);

            if (hero == null)
            {
                return NotFound();
            }

            return Ok(hero);
        }

        // POST: api/hero
        [HttpPost]
        public async Task<IActionResult> PostHero(Hero hero)
        {
            await _heroService.PostHeroService(hero);

            return CreatedAtAction(nameof(GetHero), new { id = hero.Id }, hero);
        }

        // PUT: api/hero/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Hero>> PutHero(int id, Hero hero)
        {
            var result = await _heroService.PutHeroService(id, hero);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }


        // DELETE: api/hero/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var hero = await _heroService.GetHero(id);
            if (hero == null)
            {
                return NotFound();
            }

            await _heroService.DeleteHeroService(id);

            return NoContent();
        }

        private async Task<bool> HeroExists(int id)
        {
            return await _heroService.HeroExistsService(id);
        }
    }
}