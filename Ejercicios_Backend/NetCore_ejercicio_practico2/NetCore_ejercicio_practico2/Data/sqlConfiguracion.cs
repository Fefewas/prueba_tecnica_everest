namespace NetCore_ejercicio_practico2.Data
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
