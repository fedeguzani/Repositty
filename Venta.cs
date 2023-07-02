using System.Data.SqlClient;
using System.Collections.Generic;


namespace Repositty1.Controllers
{
    public class Venta
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public long IdUsuario { get; set; }

        public void InsertarVenta()
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                try
                {
                    connection.Open();

                    // Realizar operaciones de inserción en la base de datos
                    // ...

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public class VentaDAO
        {
            public List<Venta> TraerVentas()
            {
                List<Venta> ventas = new List<Venta>();
                using (SqlConnection con = Conecion.GetConnection())
                {
                    con.Open();
                    string query = "SELECT * FROM Venta";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Venta venta = new Venta
                                {
                                    Id = Convert.ToInt64(reader["Id"]),
                                    Comentarios = reader["Comentarios"].ToString()
                                };
                                ventas.Add(venta);
                            }
                        }
                    }
                }
                return ventas;
            }
        }
    }
}
