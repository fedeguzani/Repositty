


using Repository;

namespace Repositty

{
    public class Usuario
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Contraseña { get; set; }
        public string? Mail { get; set; }
    }

    public class UsuarioDAO
    {
        public Usuario TraerUsuarioPorNombreUsuario(string nombreUsuario)
        {
            Usuario? usuario = null;
            using (NpgsqlConnection con = Conecion.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM Usuario WHERE NombreUsuario = @nombreUsuario";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("nombreUsuario", nombreUsuario);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
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
            }
            return usuario;
        }
    }

}
