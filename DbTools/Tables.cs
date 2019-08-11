using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xml_Converters.DbTools
{
   public class Tables
    {
        public static List<string> GetFilds(SqlDataReader reader)
        {
           return reader.GetSchemaTable().Rows
                                    .Cast<DataRow>()
                                    .Select(r => (string)r["ColumnName"])
                                    .ToList();
        }
        public static SqlDataReader Reader(SqlCommand command)
        {
            if (command.Connection.State == ConnectionState.Open)
                command.Connection.Close();
            if (command.Connection.State == ConnectionState.Closed)
                command.Connection.Open();
            return command.ExecuteReader();
        }
        public static SqlCommand SqlCommand(string TableName,SqlConnection connection)
        {
           string query = "SELECT * FROM " + TableName;
            SqlCommand comman = new SqlCommand(query, connection);
            return comman;
        }
        public static IList<string> ListTables(SqlConnection _connection)
        {
            List<string> tables = new List<string>();
            _connection.Open();
            DataTable dt = _connection.GetSchema("Tables");
            foreach (DataRow row in dt.Rows)
            {
                string tablename = (string)row[2];
                tables.Add(tablename);
            }
            _connection.Close();
            return tables;
        }

    }
}
