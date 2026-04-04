using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataAccessLayer
{
    public static class DataReaderExtensions
    {
        public static T? SafeGet<T>(this IDataReader reader, string columnName)
        {
            int index = reader.GetOrdinal(columnName);

            if (reader.IsDBNull(index))
                return default;

            return (T)reader.GetValue(index);
        }
    }
}
