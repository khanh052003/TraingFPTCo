using Microsoft.Data.SqlClient;

namespace TrainingFPTCo
{
    public class Database
    {
        public static string GetStrConnection()
        {
            string strConnection = @"Data Source=21AK22-COM\KHANHDNBH0021;Initial Catalog=Training;Integrated Security=True;Encrypt=True";
            return strConnection;
        }

        public static SqlConnection GetSqlConnection() 
        {
            string strConnection = Database.GetStrConnection();
            SqlConnection conn = new SqlConnection(strConnection);
            return conn;
        }
    }
}
