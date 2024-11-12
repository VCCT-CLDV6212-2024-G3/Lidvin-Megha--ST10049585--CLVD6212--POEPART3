using System.Data.SqlClient;

namespace CLVD6212_POEPART3.Models
{
    public class Order
    {
        public static string con_string = "Server=tcp:st10049585server.database.windows.net,1433;Initial Catalog=st10049585serviceapp;Persist Security Info=False;User ID=st10049585function;Password=Francis@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);

        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }

        public int insert_order(Order o)
        {
            try
            {
                string sql = "INSERT INTO Order (orderID, customerID, productID) VALUES (@OrderID, @CustomerID, @ProductID)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@OrderID", o.OrderID);
                cmd.Parameters.AddWithValue("@CustomerID", o.CustomerID);
                cmd.Parameters.AddWithValue("@ProductID", o.ProductID);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
