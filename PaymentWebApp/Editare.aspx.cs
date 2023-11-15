using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaymentWebApp
{
    public partial class Calcul : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["nr_crt"] != null)
                {
                    string nr_crt = Request.QueryString["nr_crt"];

                    string query = "SELECT * FROM angajati.gestiune WHERE nr_crt = @nr_crt";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@nr_crt", nr_crt);

                        connection.Open();

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                TextBoxNume.Text = reader["nume"].ToString();
                                TextBoxPrenume.Text = reader["prenume"].ToString();
                                TextBoxSalarBaza.Text = reader["salar_baza"].ToString();
                                TextBoxSpor.Text = reader["spor"].ToString();
                                TextBoxPremiiBrute.Text = reader["premii_brute"].ToString();
                                TextBoxRetineri.Text = reader["retineri"].ToString();
                            }
                            else
                            {
                                string alertScript = "<script>alert('A intervenit o eroare! Datele nu pot fi preluate!');</script>";
                                Response.Write(alertScript);
                                Response.Redirect("Actualizare.aspx");
                            }
                        }
                    }
                }
                else
                {
                    string alertScript = "<script>alert('A intervenit o eroare! Datele nu pot fi preluate!');</script>";
                    Response.Write(alertScript);
                    Response.Redirect("Actualizare.aspx");
                }
            }
        }
        protected void btnSalvare_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(TextBoxNume.Text) &&
                    !string.IsNullOrEmpty(TextBoxPrenume.Text) &&
                    !string.IsNullOrEmpty(TextBoxSalarBaza.Text) &&
                    !string.IsNullOrEmpty(TextBoxSpor.Text) &&
                    !string.IsNullOrEmpty(TextBoxPremiiBrute.Text) &&
                    !string.IsNullOrEmpty(TextBoxRetineri.Text))
                {
                    string nr_crt = Request.QueryString["nr_crt"];
                    string nume = TextBoxNume.Text.Trim();
                    string prenume = TextBoxPrenume.Text.Trim();

                    if (!int.TryParse(TextBoxSalarBaza.Text.Trim(), out int salarBaza) ||
                        !int.TryParse(TextBoxSpor.Text.Trim(), out int spor) ||
                        !int.TryParse(TextBoxPremiiBrute.Text.Trim(), out int premiiBrute) ||
                        !int.TryParse(TextBoxRetineri.Text.Trim(), out int retineri))
                    {
                        string alertScript = "<script>alert('Valorile numerice introduse nu sunt corecte!');</script>";
                        Response.Write(alertScript);
                        return;
                    }

                    if (!Regex.IsMatch(nume, @"^[a-zA-Z]+$") || !Regex.IsMatch(prenume, @"^[a-zA-Z]+$"))
                    {
                        string alertScript = "<script>alert('Numele și prenumele trebuie să conțină doar litere!');</script>";
                        Response.Write(alertScript);
                        return;
                    }

                    string updateQuery = "UPDATE angajati.gestiune " +
                                         "SET nume = @nume, prenume = @prenume, salar_baza = @salarBaza, " +
                                         "spor = @spor, premii_brute = @premiiBrute, retineri = @retineri " +
                                         "WHERE nr_crt = @nr_crt";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@nr_crt", nr_crt);
                        updateCommand.Parameters.AddWithValue("@nume", nume);
                        updateCommand.Parameters.AddWithValue("@prenume", prenume);
                        updateCommand.Parameters.AddWithValue("@salarBaza", salarBaza);
                        updateCommand.Parameters.AddWithValue("@spor", spor);
                        updateCommand.Parameters.AddWithValue("@premiiBrute", premiiBrute);
                        updateCommand.Parameters.AddWithValue("@retineri", retineri);

                        connection.Open();

                        updateCommand.ExecuteNonQuery();

                        connection.Close();

                        string alertScript = "<script>alert('Datele au fost actualizate cu succes!');</script>";
                        Response.Write(alertScript);
                        Response.Redirect("Actualizare.aspx");
                    }
                }
                else
                {
                    string alertScript = "<script>alert('Toate câmpurile sunt obligatorii!');</script>";
                    Response.Write(alertScript);
                }
            }
            catch (Exception ex)
            {
                string alertScript = $"<script>alert('A intervenit o eroare! Datele nu au fost actualizate!');</script>";
                Response.Redirect("Actualizare.aspx");
            }
        }
        protected void btnAnulare_Click(object sender, EventArgs e)
        {
            Response.Redirect("Actualizare.aspx");
        }
    }
}