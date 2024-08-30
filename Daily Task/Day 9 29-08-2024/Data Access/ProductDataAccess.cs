using Microsoft.Data.SqlClient;
using MVC_ADO.Models;

namespace MVC_ADO.Data_Access
{
    public class ProductDataAccess
    {
        static SqlConnection conn;
        static SqlCommand cmd;
        static void getConnection()
        {
            conn = new SqlConnection("data source =PTSQLTESTDB01;database=Sports_Sidd;integrated security=true;TrustServerCertificate=True;");
            conn.Open();
        }
        public  void insert(ProductModel Product)
        {
            getConnection();
            int id = Product.ProId;
            string name = Product.ProName;
            cmd = new SqlCommand("insert into Product values(@id,@name)", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Records inserted");
            conn.Close();

        }
        public List<ProductModel>fetch()
        {
            getConnection();
            
            cmd = new SqlCommand("select * from Product", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ProductModel> list = new List<ProductModel>();
            while (sdr.Read())
            {
                list.Add(new ProductModel() { ProId=Convert.ToInt32(sdr[0]),ProName= sdr[1].ToString() });
            }
            conn.Close();
            return list;
        }

        public ProductModel search(int id)
        {
            getConnection();
            string query = "select * from Product where ProId =" + id;
            cmd = new SqlCommand(query, conn);
            ProductModel model = new ProductModel();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                model.ProId = Convert.ToInt32(sdr[0]);
                    model.ProName = sdr[1].ToString();
            }
            conn.Close();
            return model;
        }
        public void update(ProductModel product)
        {
            getConnection();
           
            int id = product.ProId;
            string name = product.ProName;
            cmd = new SqlCommand("Update Product Set ProName =@name where ProId=@id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public  void delete(int id)
        { 
            getConnection();
            
            cmd = new SqlCommand("Delete from Product where ProId=@id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


   
}
}
