namespace Connection.Builder;

public abstract class ConnectionBuilder : IConnectionBuilder
{
    public string DbConnectionString { get; }

    public ConnectionBuilder()
    {
        DbConnectionString = GetDbConn();
    }

    protected abstract string GetDbConn();
}
