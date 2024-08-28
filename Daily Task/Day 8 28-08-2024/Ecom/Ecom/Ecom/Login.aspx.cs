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
   

    public partial class Login : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ECommerceDB"].ConnectionString;

        protected void Page_Load (object sender , EventArgs e)
        {
            lblMessage.Text = "";
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT UserID, PasswordHash, UserRole FROM Users WHERE Username = @Username", con);
                cmd.Parameters.AddWithValue("@Username", username);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string storedHash = reader["PasswordHash"].ToString();
                    string role = reader["UserRole"].ToString();

                    // For simplicity, assuming plain text passwords. Use hashed passwords in production.
                    if (storedHash == password)
                    {
                        // Set session variables and redirect based on role
                        Session["UserID"] = reader["UserID"];
                        Session["Username"] = username;
                        Session["UserRole"] = role;

                        if (role == "Admin")
                        {
                            Response.Redirect("Products.aspx");
                        }
                        else
                        {
                            Response.Redirect("CustomerSearchProduct.aspx");
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Invalid username or password.";
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid username or password.";
                }
            }
        }
    }
}