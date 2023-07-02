using System.Data.SqlClient;
using System.Collections.Generic;


namespace Repositty1.Models
{
    public static class DBHelper
    {
        private static readonly string connectionString = "Server=DESKTOP-9SJQBUK;Port=5432;Database=SistemaGestion;User Id=usuario;Password=contraseña;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
