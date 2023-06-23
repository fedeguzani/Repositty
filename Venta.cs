using Repository;

namespace Repositty
{
    public class Venta
    {
        public long Id { get; set; }
        public string? Comentarios { get; set; }
    }

    public class VentaDAO
    {
        public List<Venta> TraerVentas()
        {
            List<Venta> ventas = new List<Venta>();
            using (NpgsqlConnection con = Conecion.GetConnection())
            {
                con.Open();
                string query = "SELECT * FROM Venta";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
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
