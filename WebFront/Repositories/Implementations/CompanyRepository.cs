using System.Collections.Generic;
using System.Linq;
using WebFront.DAL;
using WebFront.Models;

namespace WebFront.Repositories.Implementations
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public ICollection<Company> GetByRegionId(int id)
        {
            return Set.Where(c => c.RegionId == id).ToList();
        }
    }
}