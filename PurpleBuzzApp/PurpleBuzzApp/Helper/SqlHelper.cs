namespace PurpleBuzzApp.Helper;

public class SqlHelper
{
    private readonly static string _connectionString = @"Server=localhost;Database=PurpleBuzzDb;Trusted_Connection=True;TrustServerCertificate=True";
    public static string GetConnectionString()
    {
        return _connectionString;
    }
}
