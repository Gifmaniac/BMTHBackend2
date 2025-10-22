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
        string TestUserId = Environment.GetEnvironmentVariable("DB_TESTUSERID");
        string TestPassword = Environment.GetEnvironmentVariable("DB_TESTPASS");
        string TestHost = Environment.GetEnvironmentVariable("DB_TESTHOST");
        string Server = Environment.GetEnvironmentVariable("DB_SERVER");

        return
            $"Server={Server};Database={TestHost}n;User Id = {TestUserId}; Password={TestPassword};TrustServerCertificate=True;";
        }
    }
}
