using JuansLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLRepository
{
    public class SQLRepository<T> : IRepository<T> where T : class
    {
        public IEnumerable<T> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllAsync(int index, int count)
        {
            throw new NotImplementedException();
        }

        public T FindByAsync(int id)
        {
            throw new NotImplementedException();
        }

        public T FindByAsync(string name)
        {
            throw new NotImplementedException();
        }

        public T FindByAsync(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
