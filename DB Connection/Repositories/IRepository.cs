﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AnimalAdoption.DB_Connection.Repositories
{
    interface IRepository <TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        bool Add(TEntity entity);
        bool AddRange(IEnumerable<TEntity> entities);
        bool Remove(TEntity entity);
        bool RemoveRange(IEnumerable<TEntity> entities);

    }
}
