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
   

    public partial class PurchaseHistory : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ECommerceDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPurchaseHistory();
            }
        }

        private void BindPurchaseHistory()
        {
            int userId = GetCurrentUserID(); 

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(@"
                SELECT P.ProductName, P.Price, PU.PurchaseDate 
                FROM Purchases PU
                INNER JOIN Products P ON PU.ProductID = P.ProductID
                WHERE PU.UserID = @UserID", con);

                da.SelectCommand.Parameters.AddWithValue("@UserID", userId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvPurchaseHistory.DataSource = dt;
                gvPurchaseHistory.DataBind();
            }
        }

        private int GetCurrentUserID()
        {
           
            return Convert.ToInt32(Session["UserID"]);
        }
    }
}