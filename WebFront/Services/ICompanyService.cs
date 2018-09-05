using System.Collections.Generic;
using WebFront.Models;

namespace WebFront.Services
{
    public interface ICompanyService : IService<Company>
    {
        ICollection<Company> GetByRegionId(int id);
    }
}
