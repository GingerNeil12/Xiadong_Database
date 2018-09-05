using System.Collections.Generic;
using WebFront.Models;

namespace WebFront.Repositories
{
    public interface INoteRepository : IRepostiory<Note>
    {
        ICollection<Note> GetByContactId(int id);
    }
}
