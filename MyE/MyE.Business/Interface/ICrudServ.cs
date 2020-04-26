using System;
using System.Collections.Generic;
using System.Text;

namespace MyE.Data.Interface
{
    public interface ICrudServ<T>
    {
        bool Save(T entity);
        bool Update(T entity);
        bool Delete(int id);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
