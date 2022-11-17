using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Connection.Builder;

public class ConnectionBuilder : IConnectionBuilder
{
    private readonly WebApplicationBuilder builder;
    private readonly IConfiguration config;
    private readonly string server;
    private readonly string port;
    private readonly string user;
    private readonly string password;
    private readonly string database;

    public string DbConnectionString { get; }
    public string LocalDbConnectionString { get; }

    public ConnectionBuilder(WebApplicationBuilder builder, string localDbName)
    {
        this.builder = builder;
        config = builder.Configuration;
        server = GetServer();
        port = GetPort();
        user = GetUser();
        password = GetPassword();
        database = GetDatabase();
        DbConnectionString = GetDbConn();
        LocalDbConnectionString = $"Server=(localdb)\\mssqllocaldb;Database={localDbName};Trusted_Connection=True;MultipleActiveResultSets=true";
    }

    private string GetServer() => config["Server"] ?? throw new ArgumentException("Missing Server secret!");

    private string GetPort() => config["DbPort"] ?? throw new ArgumentException("Missing DbPort secret!");

    private string GetUser() => config["DbUser"] ?? throw new ArgumentException("Missing DbUser secret!");

    private string GetPassword() => config["DbPassword"] ?? throw new ArgumentException("Missing DbPassword secret!");

    private string GetDatabase() => config["Database"] ?? throw new ArgumentException("Missing Database secret!");

    private string GetDbConn() => $"Data Source={server},{port}; Initial Catalog={database}; User Id ={user}; Password={password}";
}
