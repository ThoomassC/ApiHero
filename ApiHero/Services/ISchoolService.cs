using ApiHero.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHero.Services
{
    public interface ISchoolService
    {
        Task<IEnumerable<School>> GetSchoolsService();
        Task<School> GetSchoolService(int id);
        Task<School> PostSchoolService(School school);
        Task<School> PutSchoolService(int id, School school);
        Task DeleteSchoolService(int id);
        Task<bool> SchoolExistsService(int id);
    }
}
