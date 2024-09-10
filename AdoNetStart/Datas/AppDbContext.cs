using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNetStart.Datas;

internal class AppDbContext
{
    public SqlConnection connection = new("Server=NIhat\\SQLEXPRESS;Database=AdoNetPB102Db;Trusted_Connection=True;TrustServerCertificate=True");
    public void CheckConnection()
    {
        if (connection.State == ConnectionState.Closed)
        {
            connection.Open();
        }
    }

}
