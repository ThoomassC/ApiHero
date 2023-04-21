using ApiHero.Context;
using ApiHero.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHero.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly DataContext _context;

        public SchoolService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<School>> GetSchoolsService()
        {
            return await _context.Schools.ToListAsync();
        }

        public async Task<School> GetSchoolService(int id)
        {
            return await _context.Schools.FindAsync(id);
        }

        public async Task<School> PostSchoolService(School school)
        {
            _context.Schools.Add(school);
            await _context.SaveChangesAsync();

            return school;
        }

        public async Task<School> PutSchoolService(int id, School school)
        {
            _context.Entry(school).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return school;
        }

        public async Task DeleteSchoolService(int id)
        {
            var school = await _context.Schools.FindAsync(id);
            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SchoolExistsService(int id)
        {
            return await _context.Schools.AnyAsync(e => e.Id == id);
        }
    }
}
