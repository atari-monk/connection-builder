using Microsoft.AspNetCore.Builder;

namespace Connection.Builder;

public class ProductionConnectionBuilder : ConnectionBuilder
{
    private readonly ConfigConnectionData data;

    public ProductionConnectionBuilder(WebApplicationBuilder builder)
    {
        data = new ConfigConnectionData(builder.Configuration);
    }

    public override string GetDbConnectionString() => $"Data Source={data.Server},{data.Port}; Initial Catalog={data.Database}; User Id ={data.User}; Password={data.Password}";
}
