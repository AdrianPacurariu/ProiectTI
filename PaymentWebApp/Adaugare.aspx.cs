using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaymentWebApp
{
    public partial class Adaugare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AdaugaAngajat(object sender, EventArgs e)
        {
            var nume = Request.Form["nume"];
            var prenume = Request.Form["prenume"];
            var functie = Request.Form["functie"];
            var salar = Request.Form["salar"];
            var spor = Request.Form["spor"];
            var premii = Request.Form["premii"];
            var retineri = Request.Form["retineri"];

            if (string.IsNullOrEmpty(nume) || string.IsNullOrEmpty(prenume) || string.IsNullOrEmpty(functie)
        || string.IsNullOrEmpty(salar) || string.IsNullOrEmpty(spor) || string.IsNullOrEmpty(premii)
        || string.IsNullOrEmpty(retineri))
            {
                string alertScript = "<script>alert('Nu ați completat toate câmpurile!');";
                alertScript += "window.location.href='Adaugare.aspx';</script>";
                Response.Write(alertScript);
                return;
            }
            else
            {
                if (poza.PostedFile != null && poza.PostedFile.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(poza.PostedFile.FileName);
                    if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" ||
                        fileExtension == ".JPG" || fileExtension == ".JPEG" || fileExtension == ".PNG")
                    {
                        byte[] bytes;
                        using (BinaryReader br = new BinaryReader(poza.PostedFile.InputStream))
                        {
                            bytes = br.ReadBytes(poza.PostedFile.ContentLength);
                        }

                        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
                        string query = "INSERT INTO angajati.gestiune (nume, prenume, functie, salar_baza, spor, premii_brute, procente_id, retineri, poza) " +
                                       "VALUES (@Nume, @Prenume, @Functie, @Salar, @Spor, @Premii, 1, @Retineri, @Poza)";

                        try
                        {
                            using (MySqlConnection connection = new MySqlConnection(connectionString))
                            {
                                MySqlCommand command = new MySqlCommand(query, connection);
                                command.Parameters.AddWithValue("@Nume", nume);
                                command.Parameters.AddWithValue("@Prenume", prenume);
                                command.Parameters.AddWithValue("@Functie", functie);
                                command.Parameters.AddWithValue("@Salar", salar);
                                command.Parameters.AddWithValue("@Spor", spor);
                                command.Parameters.AddWithValue("@Premii", premii);
                                command.Parameters.AddWithValue("@Retineri", retineri);
                                command.Parameters.AddWithValue("@Poza", bytes);

                                connection.Open();
                                command.ExecuteNonQuery();
                                connection.Close();

                                string alertScript = "<script>alert('Angajatul a fost adăugat cu succes!');";
                                alertScript += "window.location.href='StatPlata.aspx';</script>";
                                Response.Write(alertScript);
                            }
                        }
                        catch (Exception ex)
                        {
                            string alertScript = "<script>alert('Eroare: " + ex.Message + "');</script>";
                            Response.Write(alertScript);
                        }
                    }
                }
            }

        }
    }
}