using ApiHero.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHero.Services
{
    public interface IHeroService
    {
        Task<List<Hero>> GetHeros();
        Task<Hero> GetHero(int id);
        Task<Hero> PostHeroService(Hero hero);
        Task<Hero> PutHeroService(int id, Hero hero);
        Task<bool> DeleteHeroService(int id);
        Task<bool> HeroExistsService(int id);
    }
}