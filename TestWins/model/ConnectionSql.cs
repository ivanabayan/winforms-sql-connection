using MySql.Data.MySqlClient;

namespace TestWins.Repoository;

public class ConnectionSql
{
    private readonly string _connectionString = "server=localhost;database=student;uid=root;pwd=root";

    public MySqlConnection connectSql()
    {
        try
        {
            var conn = new MySqlConnection(_connectionString);
            conn.Open(); // Test the connection
            conn.Close();
            return new MySqlConnection(_connectionString); // return a fresh connection for use
        }
        catch (Exception ex)
        {
            // If connection fails, throw an error
            throw new Exception("Database connection failed: " + ex.Message);
        }
    }
}
