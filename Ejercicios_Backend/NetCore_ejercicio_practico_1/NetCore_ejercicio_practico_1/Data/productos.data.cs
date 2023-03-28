using Dapper;
using MySql.Data.MySqlClient;
using NetCore_ejercicio_practico_1.Models;

namespace NetCore_ejercicio_practico_1.Data
{
    public class productos : Iproductos
    {
        private readonly sqlConfiguracion _connectionString;
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public productos(sqlConfiguracion connectionString)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> actualizarProducto(producto producto)
        {
            var db = dbConnection();
            var sql = @"UPDATE productos
                        SET nombre = @nombre,
                            descripcion = @descripcion
                        WHERE id = @id";
            var resultado = await db.ExecuteAsync(sql, new { producto.nombre, producto.descripcion, producto.id});
            return resultado > 0;
        }

        public async Task<bool> agregarProducto(producto producto)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO productos(nombre, descripcion)
                        VALUES(@nombre, @descripcion )";
            var resultado = await db.ExecuteAsync(sql, new { producto.nombre, producto.descripcion});
            return resultado > 0;
        }

        public async Task<bool> eliminarProducto(producto producto)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM productos WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new {Id = producto.id });
            return result > 0;
        }

        public async Task<producto> leerDetalles(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id, nombre, descripcion
                        FROM productos
                        WHERE id = @id";
            return await db.QueryFirstOrDefaultAsync<producto>(sql, new { id = id });
        }

        public async Task<IEnumerable<producto>> LeerProductos()
        {
            var db = dbConnection();
            var sql = @"SELECT id, nombre, descripcion
                        FROM productos";
            return await db.QueryAsync<producto>(sql, new { });
        }
    }
}
