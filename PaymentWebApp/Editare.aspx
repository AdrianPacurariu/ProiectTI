<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Editare.aspx.cs" Inherits="PaymentWebApp.Calcul" %>

<asp:Content ID="Editare" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container text-center">
        <div class="mt-5">
            <h2>Editare date</h2>
        </div>
        <br />
        <div class="row mt-4">
            <div class="col-md-6 offset-md-3">
                <div class="form-group">
                    <asp:Label ID="LabelNume" runat="server" Text="Nume" AssociatedControlID="TextBoxNume"></asp:Label>
                    <asp:TextBox ID="TextBoxNume" runat="server" CssClass="form-control mb-3" placeholder="Nume"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="LabelPrenume" runat="server" Text="Prenume" AssociatedControlID="TextBoxPrenume"></asp:Label>
                    <asp:TextBox ID="TextBoxPrenume" runat="server" CssClass="form-control mb-3" placeholder="Prenume"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="LabelSalarBaza" runat="server" Text="Salariu de bază" AssociatedControlID="TextBoxSalarBaza"></asp:Label>
                    <asp:TextBox ID="TextBoxSalarBaza" runat="server" CssClass="form-control mb-3" placeholder="Salariu de bază"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="LabelSpor" runat="server" Text="Spor (%)" AssociatedControlID="TextBoxSpor"></asp:Label>
                    <asp:TextBox ID="TextBoxSpor" runat="server" CssClass="form-control mb-3" placeholder="Spor (%)"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="LabelPremiiBrute" runat="server" Text="Premii brute" AssociatedControlID="TextBoxPremiiBrute"></asp:Label>
                    <asp:TextBox ID="TextBoxPremiiBrute" runat="server" CssClass="form-control mb-3" placeholder="Premii brute"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="LabelRetineri" runat="server" Text="Rețineri" AssociatedControlID="TextBoxRetineri"></asp:Label>
                    <asp:TextBox ID="TextBoxRetineri" runat="server" CssClass="form-control mb-3" placeholder="Rețineri"></asp:TextBox>
                </div>
                <asp:Button ID="btnSalvare" runat="server" Text="Salvează" CssClass="btn btn-primary btn-block" OnClick="btnSalvare_Click" />
                <asp:Button ID="btnAnulare" runat="server" Text="Anulare" CssClass="btn btn-secondary btn-block" OnClick="btnAnulare_Click" />
            </div>
        </div>
    </div>
</asp:Content>
