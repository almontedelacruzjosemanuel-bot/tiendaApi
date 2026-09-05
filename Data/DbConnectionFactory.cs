using Microsoft.Data.SqlClient;

namespace tiendaApi.Data;

public class DbConnection(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public SqlConnection CreateConnection()
    {
        return new SqlConnection(
            _configuration.GetConnectionString("DefaultConnection")
        );
    }
}