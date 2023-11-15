<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/HomePage.Master"
    AutoEventWireup="true" CodeBehind="Actualizare.aspx.cs"
    Inherits="PaymentWebApp.Actualizare" %>

<asp:Content ID="Actualizare" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container text-center">
        <div class="mt-5">
            <h2>Actualizare date</h2>
        </div>
        <br />
        <div class="row mt-4">
            <div class="col-md-4">
                <asp:DropDownList ID="DropDownListParameters" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Nr. crt." Value="nr_crt"></asp:ListItem>
                    <asp:ListItem Text="Nume" Value="nume"></asp:ListItem>
                    <asp:ListItem Text="Prenume" Value="prenume"></asp:ListItem>
                    <asp:ListItem Text="Funcție" Value="functie"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="TextBoxSearch" runat="server" CssClass="form-control" placeholder="Caută..."></asp:TextBox>
            </div>
            <div class="col-md-4">
                <asp:Button ID="ButtonSearch" runat="server" Text="Căutare" CssClass="btn btn-primary btn-block" OnClick="ButtonSearch_Click" />
            </div>
        </div>
        <br />
        <div class="text-center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" Style="margin: auto;">
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
                            <asp:HyperLink ID="HyperLinkEdit" runat="server" Text="Editare" NavigateUrl='<%# "Editare.aspx?nr_crt=" + Eval("nr_crt") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="gridview-row" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
