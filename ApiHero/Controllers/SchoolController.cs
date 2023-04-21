using ApiHero.Models;
using ApiHero.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        // GET: api/school
        [HttpGet]
        public async Task<IEnumerable<School>> GetSchools()
        {
            return await _schoolService.GetSchoolsService();
        }

        // GET: api/school/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<School>> GetSchool(int id)
        {
            var school = await _schoolService.GetSchoolService(id);

            if (school == null)
            {
                return NotFound();
            }

            return school;
        }

        // POST: api/school
        [HttpPost]
        public async Task<ActionResult<School>> PostSchool(School school)
        {
            await _schoolService.PostSchoolService(school);

            return CreatedAtAction(nameof(GetSchool), new { id = school.Id }, school);
        }

        // PUT: api/school/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchool(int id, School school)
        {
            if (id != school.Id)
            {
                return BadRequest();
            }

            if (!await _schoolService.SchoolExistsService(id))
            {
                return NotFound();
            }

            await _schoolService.PutSchoolService(id, school);

            return NoContent();
        }

        // DELETE: api/school/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            if (!await _schoolService.SchoolExistsService(id))
            {
                return NotFound();
            }

            await _schoolService.DeleteSchoolService(id);

            return NoContent();
        }

        private async Task<bool> SchoolExists(int id)
        {
            return await _schoolService.SchoolExistsService(id);
        }
    }
}
