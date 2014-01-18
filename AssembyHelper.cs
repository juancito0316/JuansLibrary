using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuansLibrary
{
    public static class AssembyHelper
    {
        public static string GetFullyQualifiedTypeName(Type type)
        {
            return type.ToString();
        }

        public static string GetFullNameAssembly(Type type)
        {
            return type.AssemblyQualifiedName;
        }

        public static void LogFullyQualifiedName(Type type, Action<string> action)
        {
            var name = type.ToString();
            action(name);
        }

        public static void LogAssemblyQualifiedName(Type type, Action<string> action)
        {
            var name = type.AssemblyQualifiedName;
            action(name);
        }
    }
}
