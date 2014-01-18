using JuansLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuansLibrary.Factories
{
    public static class RepositoryFactory
    {
        /// <summary>
        /// returns a concrete repository based on App.config configuration
        /// </summary>
        /// <typeparam name="T">ie: RepositoryFactory.GetRepository<IRepository<Person>>()</typeparam>
        /// <returns></returns>
        public static T GetRepository<T>() where T : class
        {
            var requestedType = typeof(T).ToString();
            string repoTypeName = ConfigurationManager.AppSettings[requestedType];
            Type repoType = Type.GetType(repoTypeName);
            object repoInstance = Activator.CreateInstance(repoType);

            T result = repoInstance as T;

            return result;          
        }
    }
}
