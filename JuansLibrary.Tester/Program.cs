using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuansLibrary;
using JuansLibrary.Interfaces;
using JuansLibrary.Tester.Model;
using System.IO;

namespace JuansLibrary.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(PathHelper.GetExcecutionPathDirectory());
            //Console.WriteLine(PathHelper.GetCurrentDirectory());
            //Console.WriteLine(PathHelper.GetProjectDirectory());
            //var type = typeof(IRepository<Person>);
            //AssembyHelper.LogFullyQualifiedName(type, Console.WriteLine);

            var list = ImportFromCSV();
            foreach (var p in list)
            {
                Console.WriteLine(string.Format("Imported Person : {0}, {1}, {2}, {3}", p.FirstName, p.LastName, p.UserName, p.Password));
            }
            Console.Read();

            //WriteFullyQualifiedName();
        }

        static void WriteFullyQualifiedName()
        {
            //var personRepo = Factories.RepositoryFactory.GetRepository<IRepository<Person>>();
            var type = typeof(IRepository<Person>);
            var assemblyQualifiedName = typeof(SQLRepository.SQLRepository<Person>);
            var path = PathHelper.GetProjectDirectory();
            var finalPath = Path.Combine(path, "AssemblyNames.txt");
            using (var writer = new StreamWriter(finalPath,true))
            {
                writer.WriteAsync(type.ToString());
                writer.WriteAsync('\n');
                writer.WriteAsync(assemblyQualifiedName.AssemblyQualifiedName);
            }   
        }

        static List<Person> ImportFromCSV()
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "imported.csv");
            var personList = ImportHelper.ParseCSVAsync<Person>(filePath);

            return personList.ToList();
        }
    }
}
