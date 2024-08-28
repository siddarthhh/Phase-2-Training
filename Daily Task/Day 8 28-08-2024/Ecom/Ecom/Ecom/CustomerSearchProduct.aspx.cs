using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Ecom
{
   

    public partial class CustomerSearchProduct : System.Web.UI.Page
    {

        string connectionString = ConfigurationManager.ConnectionStrings["ECommerceDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllProducts();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ProductID, ProductName, Price FROM Products WHERE ProductName LIKE '%' + @Search + '%'", con);
                da.SelectCommand.Parameters.AddWithValue("@Search", txtSearch.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvProducts.DataSource = dt;
                gvProducts.DataBind();
            }
        }

        protected void gvProducts_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "BuyProduct")
            {
                int productId = Convert.ToInt32(e.CommandArgument);
                int userId = GetCurrentUserID(); 

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Purchases (UserID, ProductID, PurchaseDate) VALUES (@UserID, @ProductID, @PurchaseDate)", con);
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.Parameters.AddWithValue("@PurchaseDate", DateTime.Now);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                
                Response.Redirect($"PurchaseConfirmation.aspx?ProductID={productId}");
            }
        }

        private int GetCurrentUserID()
        {
           
            return Convert.ToInt32(Session["UserID"]);
        }
        protected void btnShowMyOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseHistory.aspx");
        }

        private void BindAllProducts()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ProductID, ProductName, Price FROM Products", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvProducts.DataSource = dt;
                gvProducts.DataBind();
            }
        }
    }
}