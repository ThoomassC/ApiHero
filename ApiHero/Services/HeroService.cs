using ApiHero.Models;
using ApiHero.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ApiHero.Services
{
    public class HeroService : IHeroService
    {
        private readonly DataContext _context;

        public HeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Hero>>> GetHeros()
        {
            return await _context.Heros.ToListAsync();
        }

        public async Task<ActionResult<Hero>> GetHero(int id)
        {
            var hero = await _context.Heros.FindAsync(id);

            if (hero == null)
            {
                return new NotFoundResult();
            }

            return hero;
        }

        public async Task<ActionResult<Hero>> PostHeroService(Hero hero)
        {
            _context.Heros.Add(hero);
            await _context.SaveChangesAsync();

            return new CreatedAtActionResult("GetHero", "Hero", new { id = hero.Id }, hero);
        }

        public async Task<Hero> PutHeroService(int id, Hero hero)
        {
            _context.Entry(hero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HeroExistsService(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return hero;
        }


        public async Task<IActionResult> DeleteHeroService(int id)
        {
            var hero = await _context.Heros.FindAsync(id);
            if (hero == null)
            {
                return new NotFoundResult();
            }

            _context.Heros.Remove(hero);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }

        public async Task<bool> HeroExistsService(int id)
        {
            return await _context.Heros.AnyAsync(e => e.Id == id);
        }
    }
}
