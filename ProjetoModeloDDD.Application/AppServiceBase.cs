﻿using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
    public class AppServiceBase<T> : IDisposable, IAppServiceBase<T> where T : class
    {
        private readonly IServiceBase<T> _serviceBase;
        public AppServiceBase(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }
        public void Add(T entity)
        {
            _serviceBase.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public T GetbyId(int id)
        {
            return _serviceBase.GetById(id);
        }

        public void Remove(T entity)
        {
            _serviceBase.Remove(entity);
        }

        public void Update(T entity)
        {
            _serviceBase.Update(entity);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
