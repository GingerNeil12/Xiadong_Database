using System.Collections.Generic;
using WebFront.Models;

namespace WebFront.Repositories
{
    public interface ICompanyRepository : IRepostiory<Company>
    {
        ICollection<Company> GetByRegionId(int id);
    }
}
