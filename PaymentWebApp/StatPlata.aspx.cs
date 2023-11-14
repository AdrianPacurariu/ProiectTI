using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaymentWebApp
{
    public partial class StatPlata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

                string query = "SELECT nr_crt, nume, prenume, functie, salar_baza, spor, premii_brute, total_brut, retineri, virat_card, poza FROM angajati.gestiune";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Connection = conn;
                            sda.SelectCommand = cmd;

                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }
    }
}