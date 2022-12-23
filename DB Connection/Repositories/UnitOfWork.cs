using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoption.DB_Connection.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {

        private readonly DataBaseContext _dataBaseContext;
         
        public bool Complete ()
        { try
            { int result = _dataBaseContext.SaveChanges();
                if (result>0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public void Dispose ()
        {
            _dataBaseContext.Dispose();
        }
    }
}
