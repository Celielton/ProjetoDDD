using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IAppServiceBase<T> where T : class
    {
        void Add(T entity);
        T GetbyId(int id);
        IEnumerable<T> GetAll();
        void Remove(T entity);
        void Update(T entity);
        void Dispose();

    }
}
