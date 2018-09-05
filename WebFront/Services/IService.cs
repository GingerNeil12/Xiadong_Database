using System;
using System.Collections.Generic;

namespace WebFront.Services
{
    public interface IService<T> : IDisposable where T : class
    {
        string GetError();
        ICollection<T> GetAll();
        T GetById(int id);
        bool Add(T entity);
        bool Update(T entity);
    }
}
