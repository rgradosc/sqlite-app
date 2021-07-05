using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace BillTimeLibrary.DataAccess
{
    public static class SqliteDataAccess
    {
        public static List<T> LoadData<T>(string sqlStatement, Dictionary<string, object> parameters, string connectionName = "Default")
        {
            DynamicParameters p = parameters.ToDynamicParameters();

            using (IDbConnection connection = new SQLiteConnection(DataAccessHelpers.LoadConnectionString(connectionName)))
            {
                var rows = connection.Query<T>(sqlStatement, p);

                return rows.ToList();
            }
        }

        public static void SaveData(string sqlStatement, Dictionary<string, object> parameters, string connectionName = "Default")
        {
            DynamicParameters p = parameters.ToDynamicParameters();

            using (IDbConnection connection = new SQLiteConnection(DataAccessHelpers.LoadConnectionString(connectionName)))
            {
                connection.Execute(sqlStatement, p);
            }
        }

        private static DynamicParameters ToDynamicParameters(this Dictionary<string, object> parameters)
        {
            DynamicParameters p = new DynamicParameters();
            parameters.ToList().ForEach(x => p.Add(x.Key, x.Value));
            return p;
        }
    }
}
