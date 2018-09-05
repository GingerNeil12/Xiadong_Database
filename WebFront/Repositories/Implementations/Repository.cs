using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebFront.DAL;

namespace WebFront.Repositories.Implementations
{
    public class Repository<T> : IRepostiory<T> where T : class
    {
        private ApplicationDbContext _context;

        protected DbSet<T> Set { get; set; }

        public Repository()
        {
            _context = new ApplicationDbContext();
            Set = _context.Set<T>();
        }
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            Set = _context.Set<T>();
        }

        public ICollection<T> GetAll()
        {
            return Set.ToList();
        }

        public T GetById(int id)
        {
            return Set.Find(id);
        }

        public void Add(T entity)
        {
            Set.Add(entity);
        }

        public void Update(T entity)
        {
            if(_context.Entry<T>(entity).State == EntityState.Detached)
            {
                Set.Attach(entity);
            }
            _context.Entry<T>(entity).State = EntityState.Modified;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(_context != null)
                {
                    _context.Dispose();
                    _context = null;
                    Set = null;
                }
            }
        }
    }
}