using Dapper;
using MySql.Data.MySqlClient;
using NetCore_ejercicio_practico2.Model;

namespace NetCore_ejercicio_practico2.Data
{
    public class clientes : Iclientes
    {
        private readonly sqlConfiguracion _connectionString;
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public clientes(sqlConfiguracion connectionString)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<clienteModel>> leerclientes()
        {
            var db = dbConnection();
            var sql = @"SELECT id, nombre, edad
                        FROM clientes";
            return await db.QueryAsync<clienteModel>(sql, new { });
        }

        public async Task<clienteModel> leerclientesxedad(int edad)
        {
            var db = dbConnection();
            var sql = @"SELECT id, nombre, edad
                        FROM clientes
                        WHERE edad = @edad";
            return await db.QueryFirstOrDefaultAsync<clienteModel>(sql, new { edad = edad });
        }

        public async Task<clienteModel> leerclientesxid(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id, nombre, descripcion
                        FROM clientes
                        WHERE id = @id";
            return await db.QueryFirstOrDefaultAsync<clienteModel>(sql, new { id = id });

        }

        public async Task<clienteModel> leerclientesxnombre(string nombre)
        {
            var db = dbConnection();
            var sql = @"SELECT *
                        FROM clientes
                        WHERE nombre = @nombre";
            return await db.QueryFirstOrDefaultAsync<clienteModel>(sql, new { nombre = nombre });

        }
    }
}
