using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Speech.Recognition;

namespace JuansLibrary {
    /// <summary>
    /// NOTE: only supports plain POCO's for now, not N layer deep objects.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CSVImportHelper<T> where T : class {
        /// <summary>
        /// reads the given file one line at a time
        /// returning the line to the caller
        /// caller can foreach without worrying about the file being too big or disposing
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private  IEnumerable<string> ReadLines(string fileName) {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("File was not found");

            using (TextReader reader = File.OpenText(fileName)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
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
        public IList<T> Import(string fileName) {
            var list = new List<T>(); //the list that will be returned
            var properties = typeof(T).GetProperties(); //an array of the object's properties
            var headers = new List<string>(); //contains the properties of the object (ie: FirstName, LastName)

            int index = 0;
            foreach (var line in ReadLines(fileName)) {
                //the first line of the csv file is the header
                if (index == 0) {
                    var propertyNames = line.Split(',');
                    foreach (var propertyName in propertyNames) {
                        headers.Add(propertyName);
                    }
                } else {
                    //get the actual property values 
                    string[] values = line.Split(',');
                    object entity = Activator.CreateInstance(typeof(T));
                    var resolvedEntity = entity as T; //an instance of the actual generic object that was passed
                    foreach (var p in properties) {
                        //the property names of the object
                        int indexOfProp = headers.IndexOf(p.Name);
                        p.SetValue(resolvedEntity, values[indexOfProp]);
                    }

                    list.Add(resolvedEntity);
                }

                index++;
            }

            return list;
        }

    }
}

