using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoption.DB_Connection.Repositories
{
    interface IUnitOfWork :IDisposable
    {
        bool Complete();
    }
}
