using System.Collections.Generic;
using System.Linq;
using WebFront.DAL;
using WebFront.Models;

namespace WebFront.Repositories.Implementations
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public ICollection<Note> GetByContactId(int id)
        {
            return Set.Where(c => c.ContactId == id).ToList();
        }
    }
}