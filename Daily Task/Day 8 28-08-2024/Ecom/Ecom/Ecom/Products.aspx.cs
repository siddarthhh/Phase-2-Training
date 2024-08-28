using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecom
{
    public partial class Products : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ECommerceDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProducts();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Products (ProductName, Price, Quantity) VALUES (@ProductName, @Price, @Quantity)", con);
                    cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    BindProducts();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products WHERE ProductName LIKE '%' + @Search + '%'", con);
                    da.SelectCommand.Parameters.AddWithValue("@Search", txtSearch.Text);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvProducts.DataSource = dt;
                    gvProducts.DataBind();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
            }
        }

        protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditProduct")
            {
                int productId = Convert.ToInt32(e.CommandArgument);
                System.Diagnostics.Debug.WriteLine($"Edit command received. ProductID: {productId}"); // Debug line
                ViewState["EditingProductID"] = productId; // Store the product ID in ViewState
                PopulateEditForm(productId);
                pnlEdit.Visible = true;
            }
            else if (e.CommandName == "DeleteProduct")
            {
                int productId = Convert.ToInt32(e.CommandArgument);
                System.Diagnostics.Debug.WriteLine($"Delete command received. ProductID: {productId}"); // Debug line
                DeleteProduct(productId);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int editingProductID = (int)ViewState["EditingProductID"];
                System.Diagnostics.Debug.WriteLine($"Updating ProductID: {editingProductID}");
                System.Diagnostics.Debug.WriteLine($"ProductName: {txtEditProductName.Text}");
                System.Diagnostics.Debug.WriteLine($"Price: {txtEditPrice.Text}");
                System.Diagnostics.Debug.WriteLine($"Quantity: {txtEditQuantity.Text}");

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Products SET ProductName = @ProductName, Price = @Price, Quantity = @Quantity WHERE ProductID = @ProductID", con);
                    cmd.Parameters.AddWithValue("@ProductName", txtEditProductName.Text);
                    cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtEditPrice.Text));
                    cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtEditQuantity.Text));
                    cmd.Parameters.AddWithValue("@ProductID", editingProductID);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    System.Diagnostics.Debug.WriteLine($"Rows affected: {rowsAffected}");

                    if (rowsAffected > 0)
                    {
                        pnlEdit.Visible = false;
                        BindProducts();
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Update failed: No rows affected.");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlEdit.Visible = false;
        }

        private void PopulateEditForm(int productId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT ProductName, Price, Quantity FROM Products WHERE ProductID = @ProductID", con);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtEditProductName.Text = reader["ProductName"].ToString();
                    txtEditPrice.Text = reader["Price"].ToString();
                    txtEditQuantity.Text = reader["Quantity"].ToString();
                }
                con.Close();
            }
        }

        private void DeleteProduct(int productId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Delete related records from Purchases table
                    SqlCommand deletePurchasesCmd = new SqlCommand("DELETE FROM Purchases WHERE ProductID = @ProductID", con);
                    deletePurchasesCmd.Parameters.AddWithValue("@ProductID", productId);
                    deletePurchasesCmd.ExecuteNonQuery();

                    // Delete the product from Products table
                    SqlCommand deleteProductCmd = new SqlCommand("DELETE FROM Products WHERE ProductID = @ProductID", con);
                    deleteProductCmd.Parameters.AddWithValue("@ProductID", productId);
                    deleteProductCmd.ExecuteNonQuery();

                    con.Close();
                    BindProducts();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
                }
            }
        }

        private void BindProducts()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Products", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvProducts.DataSource = dt;
                gvProducts.DataBind();
            }
        }
    }
}
