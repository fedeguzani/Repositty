using System.Data.SqlClient;
using System.Collections.Generic;

namespace Repositty1.Controllers
{
    public class Producto
    {
        public long Id { get; set; }
        public string? Descripciones { get; set; }
        public decimal? Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public long IdUsuario { get; set; }

        public void InsertarProducto()
        {
            using (SqlConnection connection = DBHelper.GetConnection())
            {
                try
                {
                    {
                        con.Open();
                        string query = "SELECT * FROM Producto";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Producto producto = new Producto
                                    {
                                        Id = Convert.ToInt64(reader["Id"]),
                                        Descripciones = reader["Descripciones"].ToString(),
                                        Costo = reader["Costo"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(reader["Costo"]),
                                        PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]),
                                        Stock = Convert.ToInt32(reader["Stock"]),
                                        IdUsuario = Convert.ToInt64(reader["IdUsuario"])
                                    };
                                    productos.Add(producto);
                                }
                            }
                        }
                    }
                    return productos;

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
