using System.Collections.Generic;
using WebFront.Models;

namespace WebFront.Services
{
    public interface IContactService : IService<Contact>
    {
        ICollection<Contact> GetByCompanyId(int id);    
    }
}
