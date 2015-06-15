using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Core.DAO
{
    interface IGenericDAO<T> where T: class
    {
        T Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> All();
    }
}
