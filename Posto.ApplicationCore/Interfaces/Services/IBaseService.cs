using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Posto.ApplicationCore.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        void Remove(TEntity entity);
        //void Dispose();
    }
}
