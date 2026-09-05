using Dapper;
using tiendaApi.Models;

namespace tiendaApi.Data;

public class ProductoRepository
{
  private readonly DbConnection _dbConnection;

  public ProductoRepository(DbConnection dbConnection)
  {
    _dbConnection = dbConnection;
  }

  public async Task<IEnumerable<Producto>> GetProductos()
  {
    using var connection = _dbConnection.CreateConnection();

    string sql = "SELECT * FROM Productos";

    return await connection.QueryAsync<Producto>(sql);
  }
}