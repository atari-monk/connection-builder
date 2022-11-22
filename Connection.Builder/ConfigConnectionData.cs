using Microsoft.Extensions.Configuration;

namespace Connection.Builder;

public class ConfigConnectionData
{
    private readonly IConfiguration config;
    private readonly ConnectionData connectionData;

    public string Server => connectionData.Server;
    public string Port => connectionData.Port;
    public string User => connectionData.User;
    public string Password => connectionData.Password;
    public string Database => connectionData.Database;

    public ConfigConnectionData(IConfiguration config)
    {
        this.config = config;
        connectionData = new ConnectionData(GetServer(), GetPort(), GetUser(), GetPassword(), GetDatabase());
    }

    protected virtual string GetServer() => config["Server"] ?? throw new ArgumentException("Missing Server secret!");

    protected virtual string GetPort() => config["DbPort"] ?? "1433";

    protected virtual string GetUser() => config["DbUser"] ?? throw new ArgumentException("Missing DbUser secret!");

    protected virtual string GetPassword() => config["DbPassword"] ?? throw new ArgumentException("Missing DbPassword secret!");

    protected virtual string GetDatabase() => config["Database"] ?? throw new ArgumentException("Missing Database secret!");
}
