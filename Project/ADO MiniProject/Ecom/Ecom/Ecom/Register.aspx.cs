using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System;
using System.Data.SqlClient;
using System.Configuration;


namespace Ecom
{
    public partial class Register : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ECommerceDB"].ConnectionString;

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = ddlRole.SelectedValue;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, PasswordHash, UserRole) VALUES (@Username, @PasswordHash, @UserRole)", con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@PasswordHash", password); 
                cmd.Parameters.AddWithValue("@UserRole", role);
                con.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Registration successful!";
                    Response.Redirect("Login.aspx");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) 
                    {
                        lblMessage.Text = " The username already exists. Please choose a different username.";
                    }
                    else
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}