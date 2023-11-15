using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Org.BouncyCastle.Crypto.Digests.SkeinEngine;
using System.Data;

namespace PaymentWebApp
{
    public partial class Stergere : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string deleteStatus = Request.QueryString["deleteStatus"];

                if (!string.IsNullOrEmpty(deleteStatus))
                {
                    if (deleteStatus == "success")
                    {
                        string alertScript = "<script>alert('Ștergerea a fost efectuată cu succes!');</script>";
                        Response.Write(alertScript);
                    }
                    else if (deleteStatus == "failure")
                    {
                        string alertScript = "<script>alert('Nu s-a găsit înregistrarea pentru ștergere!');</script>";
                        Response.Write(alertScript);
                    }
                }
            }
        }


        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string numeInput = TextBoxNumeSearch.Text.Trim();
            string prenumeInput = TextBoxPrenumeSearch.Text.Trim();

            if (string.IsNullOrEmpty(numeInput) && string.IsNullOrEmpty(prenumeInput))
            {
                string alertScript = "<script>alert('Introduceți cel puțin un nume sau prenume pentru căutare!');</script>";
                Response.Write(alertScript);
                return;
            }

            Regex onlyLettersRegex = new Regex("^[a-zA-ZăîâșțĂÎÂȘȚ]+$");

            if (!string.IsNullOrEmpty(numeInput) && !onlyLettersRegex.IsMatch(numeInput))
            {
                string alertScript = "<script>alert('Numele poate conține doar litere!');</script>";
                Response.Write(alertScript);
                return;
            }

            if (!string.IsNullOrEmpty(prenumeInput) && !onlyLettersRegex.IsMatch(prenumeInput))
            {
                string alertScript = "<script>alert('Prenumele poate conține doar litere!');</script>";
                Response.Write(alertScript);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM angajati.gestiune WHERE ";

                if (!string.IsNullOrEmpty(numeInput))
                {
                    query += "nume LIKE @nume";

                    if (!string.IsNullOrEmpty(prenumeInput))
                    {
                        query += " OR ";
                    }
                }

                if (!string.IsNullOrEmpty(prenumeInput))
                {
                    query += "prenume LIKE @prenume";
                }

                MySqlCommand command = new MySqlCommand(query, connection);

                if (!string.IsNullOrEmpty(numeInput))
                {
                    command.Parameters.AddWithValue("@nume", "%" + numeInput + "%");
                }

                if (!string.IsNullOrEmpty(prenumeInput))
                {
                    command.Parameters.AddWithValue("@prenume", "%" + prenumeInput + "%");
                }

                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                connection.Close();

                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = dataSet;
                    GridView1.DataBind();
                }
                else
                {
                    string alertScript = "<script>alert('Nu s-a gasit nici o inregistrare!');</script>";
                    Response.Write(alertScript);
                    return;
                }
            }
        }
        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex;
                if (int.TryParse(e.CommandArgument.ToString(), out rowIndex) && rowIndex >= 0 && rowIndex < GridView1.Rows.Count)
                {
                    int nr_crt = Convert.ToInt32(GridView1.DataKeys[rowIndex].Value);

                    string deleteQuery = "DELETE FROM angajati.gestiune WHERE nr_crt = @nr_crt";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@nr_crt", nr_crt);

                        try
                        {
                            connection.Open();
                            int rowsAffected = deleteCommand.ExecuteNonQuery();
                            connection.Close();

                            if (rowsAffected > 0)
                            {
                                string alertScript = $"<script>alert('Ștergerea a fost efectuată cu succes!');</script>";
                                Response.Write(alertScript);
                                Response.Redirect("Stergere.aspx?deleteStatus=success");
                            }
                            else
                            {
                                string alertScript = "<script>alert('Nu s-a găsit înregistrarea pentru ștergere!');</script>";
                                Response.Write(alertScript);
                            }
                        }
                        catch (Exception ex)
                        {
                            string alertScript = $"<script>alert('A intervenit o eroare! Ștergerea nu a fost efectuată!');</script>";
                            Response.Write(alertScript);
                        }
                    }
                } else
                {
                    string alertScript = $"<script>alert('A intervenit o eroare! Ștergerea nu a fost efectuată!');</script>";
                    Response.Write(alertScript);
                }
            }
        }
    }
}