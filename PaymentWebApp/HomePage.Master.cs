using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaymentWebApp
{
    public partial class HomePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                connectToDB();
            }
        }
        private void connectToDB()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Session["DatabaseConnection"] = connection;
                }
            }
            catch (Exception ex)
            {
                // daca nu se poate conecta
                Response.Redirect("PaginaEroare.html");
            }
        }
    }
}