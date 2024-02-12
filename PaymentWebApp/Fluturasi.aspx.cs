using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaymentWebApp
{
    public partial class Fluturasi : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT nr_crt, nume, prenume, functie, salar_baza, spor, premii_brute, " +
                                       "total_brut, brut_impozabil, impozit, cas, cass, retineri, virat_card " +
                                       "FROM gestiune";

                        DataSet ds = new DataSet();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                        adapter.Fill(ds, "GestiuneData");

                        //ReportDocument crystalReport = new ReportDocument();

                        //crystalReport.Load(Server.MapPath("~/FluturasiSalariu.rpt"));
                        //crystalReport.SetDataSource(ds.Tables["GestiuneData"]);

                        //Session["FluturasSalariu"] = crystalReport;

                        //CrystalReportViewer1.ReportSourceID = "FluturasSalariu";
                        //CrystalReportViewer1.ReportSource = crystalReport;
                        //CrystalReportViewer1.RefreshReport();


                    }
                }
                catch (Exception ex)
                {
                    string alertScript = "<script>alert('A intervenit o eroare! Raportul nu a putut fi generat!');</script>";
                    Response.Write(alertScript);
                }
            }
        }
    }
}