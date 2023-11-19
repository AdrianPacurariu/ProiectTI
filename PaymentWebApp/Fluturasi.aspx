<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Fluturasi.aspx.cs" Inherits="PaymentWebApp.Fluturasi" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Fluturasi" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container text-center">
        <div class="mt-5">
            <h2>Fluturași de salariu</h2>
        </div>
        <br />
        <center>

            <div class="report-container">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" BorderStyle="Solid" Height="50px" Width="350px" />
            </div>

        </center>
        <br />
    </div>
</asp:Content>
