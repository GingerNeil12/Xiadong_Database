using System;
using System.Collections.Generic;

namespace WebFront.Repositories
{
    public interface IRepostiory<T> : IDisposable where T : class
    {
        ICollection<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        int SaveChanges();
    }
}
