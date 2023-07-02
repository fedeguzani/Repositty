
using System.Data.SqlClient;
using System.Collections.Generic;


namespace Repositty1.Controllers
{
    public class Usuario
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Contraseña { get; set; }
        public string? Mail { get; set; }

        public void InsertarUsuario()
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Usuario WHERE NombreUsuario = @nombreUsuario";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("nombreUsuario", nombreUsuario);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuario = new Usuario
                                {
                                    Id = Convert.ToInt64(reader["Id"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                    NombreUsuario = reader["NombreUsuario"].ToString(),
                                    Contraseña = reader["Contraseña"].ToString(),
                                    Mail = reader["Mail"].ToString()
                                };
                            }
                        }
                    }

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
