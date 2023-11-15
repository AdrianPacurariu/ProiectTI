using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI;

namespace PaymentWebApp
{
    public partial class Actualizare : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        private string defaultQuery = "SELECT nr_crt, nume, prenume, functie, salar_baza, spor, premii_brute, total_brut, retineri, virat_card, poza FROM angajati.gestiune";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView(defaultQuery);
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string selectedParameter = DropDownListParameters.SelectedValue;
            string searchKeyword = TextBoxSearch.Text;

            string query = $"SELECT nr_crt, nume, prenume, functie, salar_baza, spor, premii_brute, total_brut, retineri, virat_card, poza FROM angajati.gestiune WHERE {selectedParameter} = @searchKeyword";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@searchKeyword", searchKeyword);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }
                else
                {
                    BindGridView(defaultQuery);
                    string alertScript = "<script>alert('Nu s-a găsit nicio înregistrare după criteriul căutat.');</script>";
                    Response.Write(alertScript);
                }
            }
        }

        private void BindGridView(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);

                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
        }
    }
}
