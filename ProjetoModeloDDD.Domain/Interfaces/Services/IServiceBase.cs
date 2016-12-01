
using System.Collections.Generic;


namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : class
    {
        void Add(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Remove(T entity);
        void Dispose();

    }
}
