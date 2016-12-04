
using ProjetoModeloDDD.Data.Context;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoModeloDDD.Data.Repositories
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T: class
    {
        protected readonly ProjetoModeloContex db = new ProjetoModeloContex();
        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }


        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }


        public void Dispose()
        {
            if (db != null)
                db.Dispose();
        }
    }
}
