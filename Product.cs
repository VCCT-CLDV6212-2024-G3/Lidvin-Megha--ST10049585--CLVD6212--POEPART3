using System.Data.SqlClient;

namespace CLVD6212_POEPART3.Models
{
    public class Product
    {
        public static string con_string = "Server=tcp:st10049585server.database.windows.net,1433;Initial Catalog=st10049585serviceapp;Persist Security Info=False;User ID=st10049585function;Password=Francis@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);

        public int ProductID { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string Category { get; set; }

        public int Availability { get; set; }

        public int insert_product(Product p)
        {

            try
            {
                string sql = "INSERT INTO Product (productName, productPrice, productCategory, productAvailability) VALUES (@Name, @Price, @Category, @Availability)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Availability", p.Availability);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw ex;
            }


        }

        public static List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM Product";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Product product = new Product();
                    product.ProductID = Convert.ToInt32(rdr["productID"]);
                    product.Name = rdr["productName"].ToString();
                    product.Price = rdr["productPrice"].ToString();
                    product.Category = rdr["productCategory"].ToString();
                    product.Availability = Convert.ToInt32(rdr["productAvailability"]);

                    products.Add(product);
                }
            }

            return products;
        }
    }
}
