using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : class
    {
       
        IEnumerable<T> Read();
        T GetById( int id);
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);

    }
}
