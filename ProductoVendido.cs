using System.Data.SqlClient;
using System.Collections.Generic;


namespace Repositty1.Models;

    public class ProductoVendido
 {
    public long Id { get; set; }
    public int Stock { get; set; }
    public long IdProducto { get; set; }
    public long IdVenta { get; set; }
 }

    public class ProductoVendidoDAO
 {
    public List<ProductoVendido> TraerProductosVendidos()
    {
        List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
        using (SqlConnection con = DBHelper.GetConnection())
        {
            con.Open();
            string query = "SELECT * FROM ProductoVendido";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductoVendido productoVendido = new ProductoVendido
                        {
                            Id = Convert.ToInt64(reader["Id"]),
                            Stock = Convert.ToInt32(reader["Stock"]),
                            IdProducto = Convert.ToInt64(reader["IdProducto"]),
                            IdVenta = Convert.ToInt64(reader["IdVenta"])
                        };
                        productosVendidos.Add(productoVendido);
                    }
                }
            }
        }
        return productosVendidos;
    }
  }

