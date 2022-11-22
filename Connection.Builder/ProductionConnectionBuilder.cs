using Microsoft.AspNetCore.Builder;

namespace Connection.Builder;

public class ProductionConnectionBuilder : ConnectionBuilder
{
    private readonly ConfigConnectionData data;

    public ProductionConnectionBuilder(WebApplicationBuilder builder)
        : base()
    {
        data = new ConfigConnectionData(builder.Configuration);
    }

    protected override string GetDbConn() => $"Data Source={data.Server},{data.Port}; Initial Catalog={data.Database}; User Id ={data.User}; Password={data.Password}";
}
