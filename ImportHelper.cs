using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Speech.Recognition;

namespace JuansLibrary
{
    public static class ImportHelper
    {
        /// <summary>
        /// reads the given file one line at a time
        /// returning the line to the caller
        /// caller can foreach without worrying about the file being too big or disposing
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static IEnumerable<string> ReadLines(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("File was not found");

            using (TextReader reader = File.OpenText(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        /// <summary>
        /// Important *Make sure the column header names of the csv file match the property names of the object.
        /// The order of the column headers does not matter.
        /// </summary>
        /// <typeparam name="T">the class type of the object to build based on the csv</typeparam>
        /// <param name="fileName">a valid file path to the csv file</param>
        /// <returns></returns>
        public static IList<T> ParseCSVAsync<T>(string fileName) where T : class, new()
        {
            var list = new List<T>(); //the list that will be returned

            //object type = Activator.CreateInstance(typeof(T));
            //var resolvedType = type as T; //an instance of the actual generic object that was passed
            //var props = typeof(T).GetProperties();

            var properties = typeof(T).GetProperties(); //an array of the object's properties
            var headers = new List<string>(); //contains the properties of the object (ie: FirstName, LastName)
            
            int index = 0;
            foreach (var line in ReadLines(fileName))
            {
                //the first line of the csv file is the header
                if (index == 0)
                {
                    var propertyNames = line.Split(',');
                    foreach (var propertyName in propertyNames)
                    {
                        headers.Add(propertyName);
                    }
                }
                else //get the actual property values
                {
                    string[] values = line.Split(',');
                    object entity = Activator.CreateInstance(typeof(T));
                    var resolvedEntity = entity as T; //an instance of the actual generic object that was passed
                    foreach (var p in properties) //the property names of the object
                    {
                        int indexOfProp = headers.IndexOf(p.Name);
                        p.SetValue(resolvedEntity, values[indexOfProp]);      
                    }

                    list.Add(resolvedEntity);
                }

                index++;
            }

            return list;
        }

        public static void ParseCSV(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string input = reader.ReadToEnd();
                
                string[] lines = input.Split('\n');
                string headers = lines[0];
                
                //split the header by comma
                var headerNames = headers.Split(',');

                int userNameIndex = Array.FindIndex(headerNames, new Predicate<string>( (s) => s.Contains("UserName")));
                int nameIndex = Array.FindIndex(headerNames, new Predicate<string>((s) => s.Contains("FirstName")));
                int lastNameIndex = Array.FindIndex(headerNames, new Predicate<string>( (s) => s.Contains("LastName")));

                int index = -1;
                foreach (var l in lines)
                {
                    index++;
                    if (index == 0)
                        continue;
                    
                    string[] properties = l.Split(',');
                    User user = new User { UserName = properties[userNameIndex], FirstName = properties[nameIndex], LastName = properties[lastNameIndex] };
                }
            }
        }

      }
  }

