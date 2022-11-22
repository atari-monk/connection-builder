namespace Connection.Builder;

public abstract class ConnectionBuilder : IConnectionBuilder
{
    public abstract string GetDbConnectionString();
}
