using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JuansLibrary
{
    public static class PathHelper
    {
        /// <summary>
        /// returns C:\Users\Public\Documents\JuanLibrary\bin\Debug
        /// </summary>
        /// <returns></returns>
        public static string GetExcecutionPathDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// returns C:\Users\Public\Documents\JuanLibrary\bin\Debug
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        public static string GetProjectDirectory()
        {
            return Directory.GetParent(Assembly.GetExecutingAssembly().Location).Parent.Parent.FullName;
        }


    }
}
