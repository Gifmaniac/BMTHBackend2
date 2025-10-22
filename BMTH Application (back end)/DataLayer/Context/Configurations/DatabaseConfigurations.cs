using DotNetEnv;

namespace DataLayer.Context.Configurations
{
    public static class DatabaseConfigurations
    {
        static DatabaseConfigurations()
        {
            Env.Load();
        }
        public static string GetTestDatabaseConnection()
        {
        string TestUserId = Environment.GetEnvironmentVariable("DB_TESTUSERID") ?? String.Empty;
        string TestPassword = Environment.GetEnvironmentVariable("DB_TESTPASS") ?? String.Empty;
        string TestHost = Environment.GetEnvironmentVariable("DB_TESTHOST") ?? String.Empty;
        string Server = Environment.GetEnvironmentVariable("DB_SERVER") ?? String.Empty;

        return
            $"Server={Server};Database={TestHost}n;User Id = {TestUserId}; Password={TestPassword};TrustServerCertificate=True;";
        }
    }
}
