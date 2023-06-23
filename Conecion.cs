
using Npgsql;


namespace Repository
{
    
        
    public static class Conecion
    {
        private static readonly string connectionString = "Server=DESKTOP-9SJQBUK;Port=5432;Database=SistemaGestion;User Id=usuario;Password=contraseña;";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
