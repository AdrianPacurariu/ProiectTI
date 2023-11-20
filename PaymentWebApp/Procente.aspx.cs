using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web;

namespace PaymentWebApp
{
    public partial class Procente : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InfoLabel.Visible = true;
                LoginPanel.Visible = true;
                DataPanel.Visible = false;
                ErrorLabel.Visible = false;
            }
            else
            {
                if (Request.Form["__EVENTTARGET"] == "BackButton")
                {
                    InfoLabel.Visible = true;
                    LoginPanel.Visible = true;
                    DataPanel.Visible = false;
                    ErrorLabel.Visible = false;
                }
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string enteredPassword = PasswordTextbox.Text;
            string storedPassword = RetrievePassword();

            if (storedPassword != null && VerifyPassword(enteredPassword, storedPassword))
            {
                InfoLabel.Visible = false;
                LoginPanel.Visible = false;
                DataPanel.Visible = true;
                DisplayProcenteData();
            }
            else
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "Parolă incorectă. Încercați din nou.";
                ErrorLabel.ForeColor = Color.Red;
            }
        }

        protected void BackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        private string RetrievePassword()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string selectQuery = "SELECT password FROM security";
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return (result != null) ? result.ToString() : null;
                }
                catch (Exception ex)
                {
                    string alertScript = "<script>alert('A intervenit o eroare!');</script>";
                    Response.Write(alertScript);
                    return null;
                }
            }
        }

        private bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            return (ComputeSha256Hash(enteredPassword) == storedHashedPassword);
        }

        protected void ProcenteGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string[] columnNames = { "cas_procent", "cass_procent", "impozit_procent" };

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (float.TryParse(e.Row.Cells[i].Text, out float value) && i < columnNames.Length)
                    {
                        int percentage = (int)(value * 100);
                        string columnName = columnNames[i];

                        e.Row.Cells[i].Text = $"{percentage}% - <a href='#' class='editLink' onclick='editCell(this, \"{columnName}\", {i});return false;'>Editează</a>";
                    }
                }
            }
        }





        private static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void DisplayProcenteData()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string selectQuery = "SELECT cas_procent, cass_procent, impozit_procent FROM procente";

                MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    adapter.Fill(dataTable);

                    ProcenteGridView.DataSource = dataTable;
                    ProcenteGridView.DataBind();
                }
                catch (Exception ex)
                {
                    string alertScript = "<script>alert('A intervenit o eroare: " + ex.Message + "');</script>";
                    Response.Write(alertScript); ;
                }
            }
        }

        [System.Web.Services.WebMethod]
        public static string UpdateProcenteValue(string columnName, float newValue)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            try
            {
                float updatedValue = newValue / 100;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string updateQuery = $"UPDATE procente SET {columnName} = @updatedValue";
                    MySqlCommand command = new MySqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@updatedValue", updatedValue);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return "Valoarea a fost actualizată cu succes!";
                    }
                    else
                    {
                        return "A intervenit o eroare la actualizarea valorii!";
                    }
                }
            }
            catch (Exception ex)
            {
                return "A intervenit o eroare!" + ex.Message;
            }
        }


        [System.Web.Services.WebMethod]
        public static string ChangePassword(string newPassword)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            try
            {
                string encryptedPassword = ComputeSha256Hash(newPassword);

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string updateQuery = "UPDATE security SET password = @password";
                    MySqlCommand command = new MySqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@password", encryptedPassword);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return "Parola a fost schimbată cu succes!";
                    }
                    else
                    {
                        return "A intervenit o eroare la schimbarea parolei!";
                    }
                }
            }
            catch (Exception ex)
            {
                return "A intervenit o eroare!";
            }
        }

    }
}