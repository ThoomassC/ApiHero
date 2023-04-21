using ApiHero.Context;
using ApiHero.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHero.Services
{
    public class PowerService : IPowerService
    {
        private readonly DataContext _context;

        public PowerService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Power>> GetPowersService()
        {
            return await _context.Powers.ToListAsync();
        }

        public async Task<Power> GetPowerService(int id)
        {
            return await _context.Powers.FindAsync(id);
        }

        public async Task<Power> PostPowerService(Power power)
        {
            _context.Powers.Add(power);
            await _context.SaveChangesAsync();

            return power;
        }

        public async Task<Power> PutPowerService(int id, Power power)
        {
            _context.Entry(power).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return power;
        }

        public async Task DeletePowerService(int id)
        {
            var power = await _context.Powers.FindAsync(id);
            _context.Powers.Remove(power);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> PowerExistsService(int id)
        {
            return await _context.Powers.AnyAsync(e => e.Id == id);
        }
    }
}

