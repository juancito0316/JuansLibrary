using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuansLibrary {
    public static class DbReaderExtensions {

        public static T GetAsDefaultIfDbNull<T>(this DataTableReader reader, int index) {
            return reader[index] == DBNull.Value ? default(T) : (T)reader[index];
        }

        public static T GetAsDefaultIfDbNull<T>(this DataTableReader reader, string column) {
            var index = reader.GetOrdinal(column);
            return reader[index] == DBNull.Value ? default(T) : (T)reader[index];
        }
    }
}
