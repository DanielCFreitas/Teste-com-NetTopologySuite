using System;
using System.Collections.Generic;
using System.Text;

namespace GeoTest.Data.Repository
{
    interface IRepository<T> where T : class
    {
        T Get(Guid Id);
    }
}
