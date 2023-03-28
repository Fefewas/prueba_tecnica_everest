namespace NetCore_ejercicio_practico_1.Data
{
    public class sqlConfiguracion
    {
        public sqlConfiguracion(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }
    }
}
