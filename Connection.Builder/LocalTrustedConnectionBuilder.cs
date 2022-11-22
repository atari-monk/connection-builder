namespace Connection.Builder;

public class LocalTrustedConnectionBuilder : ConnectionBuilder
{
    private readonly ConnectionData data;

    public LocalTrustedConnectionBuilder(string localDbName)
    {
        data = new ConnectionData(@"(localdb)\mssqllocaldb", "", "", "", localDbName);
    }

    public override string GetDbConnectionString() => $"Server={data.Server};Database={data.Database};Trusted_Connection=True;MultipleActiveResultSets=true";
}
