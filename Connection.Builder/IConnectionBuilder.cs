namespace Connection.Builder;

public interface IConnectionBuilder
{
    string DbConnectionString { get; }
    string LocalDbConnectionString { get; }
}
