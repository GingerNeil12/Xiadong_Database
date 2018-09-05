using System.Collections.Generic;
using WebFront.Models;

namespace WebFront.Services
{
    public interface INoteService  : IService<Note>
    {
        ICollection<Note> GetByContactId(int id);
    }
}
