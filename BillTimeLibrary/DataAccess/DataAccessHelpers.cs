using System.Configuration;

namespace BillTimeLibrary.DataAccess
{
    public static class DataAccessHelpers
    {
        internal static string LoadConnectionString(string connectionName = "Default")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
    }
}
