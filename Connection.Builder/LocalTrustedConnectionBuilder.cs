namespace Connection.Builder;

public class LocalTrustedConnectionBuilder : ConnectionBuilder
{
    private readonly ConnectionData data;

    public LocalTrustedConnectionBuilder(string localDbName)
    {
        data = new ConnectionData("(localdb)\\mssqllocaldb", "1433", "", "", localDbName);
    }

    protected override string GetDbConn() => $"Server={data.Server},{data.Port};Database={data.Database};Trusted_Connection=True;MultipleActiveResultSets=true";
}
