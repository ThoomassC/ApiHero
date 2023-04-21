using ApiHero.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHero.Services
{
    public interface IPowerService
    {
        Task<IEnumerable<Power>> GetPowersService();
        Task<Power> GetPowerService(int id);
        Task<Power> PostPowerService(Power power);
        Task<Power> PutPowerService(int id, Power power);
        Task DeletePowerService(int id);
        Task<bool> PowerExistsService(int id);
    }
}
