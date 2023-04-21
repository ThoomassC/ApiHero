using ApiHero.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHero.Services
{
    public interface IHeroService
    {
        Task<ActionResult<IEnumerable<Hero>>> GetHeros();
        Task<ActionResult<Hero>> GetHero(int id);
        Task<ActionResult<Hero>> PostHeroService(Hero hero);
        Task<Hero> PutHeroService(int id, Hero hero);
        Task<IActionResult> DeleteHeroService(int id);
        Task<bool> HeroExistsService(int id);
    }
}