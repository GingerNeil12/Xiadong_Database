using System.Collections.Generic;
using WebFront.Models;

namespace WebFront.Repositories
{
    public interface IContactRepository : IRepostiory<Contact>
    {
        ICollection<Contact> GetByCompanyId(int id);
    }
}
