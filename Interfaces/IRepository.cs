using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuansLibrary.Interfaces
{
    /// <summary>
    /// Generic repository
    /// </summary>
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllAsync();
        IEnumerable<T> GetAllAsync(int index, int count);
        T FindByAsync(int id);
        T FindByAsync(string name);
        T FindByAsync(Func<T, bool> predicate);

        void AddAsync(T entity);
        void RemoveAsync(T entity);
        int SaveAsync();
    }
}
