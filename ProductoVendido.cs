using Repository;

namespace Repositty
{
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
            using (NpgsqlConnection con = Conecion.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM ProductoVendido";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
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

}
