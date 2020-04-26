using System;
using System.Collections.Generic;
using System.Text;

namespace MyE.Data.Interface
{
    public interface ICrudServV2<T>
    {
        bool Save(T entity);
        bool Update(T entity);
        bool Delete(string id);
        IEnumerable<T> GetAll();
        T Get(string id);
    }
}
