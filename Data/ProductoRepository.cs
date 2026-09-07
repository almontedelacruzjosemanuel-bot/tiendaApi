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

    // GET: Obtener todos los productos
    public async Task<IEnumerable<Producto>> GetProductos()
    {
        using var connection = _dbConnection.CreateConnection();

        string sql = "SELECT * FROM Productos";

        return await connection.QueryAsync<Producto>(sql);
    }

    // GET: Obtener un producto por ID
    public async Task<Producto?> GetProducto(int id)
    {
        using var connection = _dbConnection.CreateConnection();

        string sql = "SELECT * FROM Productos WHERE Id = @Id";

        return await connection.QueryFirstOrDefaultAsync<Producto>(
            sql,
            new { Id = id }
        );
    }

    // POST: Crear un producto
    public async Task<int> CrearProducto(Producto producto)
    {
        using var connection = _dbConnection.CreateConnection();

        string sql = @"
            INSERT INTO Productos (Nombre, Precio, Stock)
            VALUES (@Nombre, @Precio, @Stock);

            SELECT CAST(SCOPE_IDENTITY() AS INT);
        ";

        return await connection.ExecuteScalarAsync<int>(
            sql,
            producto
        );
    }

    // PUT: Actualizar un producto
    public async Task ActualizarProducto(Producto producto)
    {
        using var connection = _dbConnection.CreateConnection();

        string sql = @"
            UPDATE Productos
            SET Nombre = @Nombre,
                Precio = @Precio,
                Stock = @Stock
            WHERE Id = @Id
        ";

        await connection.ExecuteAsync(sql, producto);
    }

    // DELETE: Eliminar un producto
    public async Task EliminarProducto(int id)
    {
        using var connection = _dbConnection.CreateConnection();

        string sql = "DELETE FROM Productos WHERE Id = @Id";

        await connection.ExecuteAsync(
            sql,
            new { Id = id }
        );
    }
}