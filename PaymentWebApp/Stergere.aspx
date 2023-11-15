<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Stergere.aspx.cs" Inherits="PaymentWebApp.Stergere" %>

<asp:Content ID="Stergere" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container text-center">
        <div class="mt-5">
            <h2>Ștergere din gestiune</h2>
        </div>
        <div class="row mt-4">
            <div class="col-md-4">
                <asp:TextBox ID="TextBoxNumeSearch" runat="server" CssClass="form-control" placeholder="Introdu numele..."></asp:TextBox>
            </div>
            <div class="col-md-2 text-center">
                <asp:Label ID="LabelSiSau" runat="server" Text="si/sau" CssClass="form-control" Style="font-size: 14px; border: none;"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="TextBoxPrenumeSearch" runat="server" CssClass="form-control" placeholder="Introdu prenumele..."></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Button ID="ButtonSearch" runat="server" Text="Căutare" CssClass="btn btn-primary btn-block" OnClick="ButtonSearch_Click" />
            </div>
        </div>
        <br />
        <div class="text-center">
            <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand1" AutoGenerateColumns="False" CssClass="table table-bordered" Style="margin: auto;" DataKeyNames="nr_crt">
                <Columns>
                    <asp:BoundField DataField="nr_crt" HeaderText="Nr. crt." />
                    <asp:BoundField DataField="nume" HeaderText="Nume" />
                    <asp:BoundField DataField="prenume" HeaderText="Prenume" />
                    <asp:BoundField DataField="functie" HeaderText="Funcție" />
                    <asp:BoundField DataField="salar_baza" HeaderText="Salariu de bază" />
                    <asp:BoundField DataField="spor" HeaderText="Spor (%)" />
                    <asp:BoundField DataField="premii_brute" HeaderText="Premii brute" />
                    <asp:BoundField DataField="retineri" HeaderText="Rețineri" />
                    <asp:BoundField DataField="virat_card" HeaderText="Virat card" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButtonDelete" runat="server" Text="Ștergere" CommandName="DeleteRow" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="return confirmDelete()"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="gridview-row" />
            </asp:GridView>
        </div>
    </div>
    <script>
        function confirmDelete() {
            if (confirm("Confirmați ștergerea angajatului din gestiune?")) {
                return true;
            } else {
                return false;
            }
        }
    </script>

</asp:Content>
