using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AnimalAdoption.DB_Connection.Repositories
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity: class
    {
        private readonly DataBaseContext _dataBaseContext;
        public Repository(DataBaseContext dataBaseContext)
        {
            this._dataBaseContext = dataBaseContext;
        }

        public bool Add(TEntity entity)
        {
            try
            {
                _dataBaseContext.Set<TEntity>().Add(entity);
                _dataBaseContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                throw ex;
            }
        }

        public bool AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _dataBaseContext.Set<TEntity>().AddRange(entities);
                _dataBaseContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dataBaseContext.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int id)
        {
            return _dataBaseContext.Set<TEntity>().Find(id);

        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dataBaseContext.Set<TEntity>().ToList();
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _dataBaseContext.Set<TEntity>().Remove(entity);
                _dataBaseContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _dataBaseContext.Set<TEntity>().RemoveRange(entities);
                _dataBaseContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
