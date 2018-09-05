using System.Collections.Generic;
using System.Linq;
using WebFront.DAL;
using WebFront.Models;

namespace WebFront.Repositories.Implementations
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public ICollection<Contact> GetByCompanyId(int id)
        {
            return Set.Where(c => c.CompanyId == id).ToList();
        }
    }
}