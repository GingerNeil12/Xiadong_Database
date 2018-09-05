using WebFront.DAL;
using WebFront.Models;

namespace WebFront.Repositories.Implementations
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        public RegionRepository(ApplicationDbContext context)
            :base(context)
        {

        }
    }
}