<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="StatPlata.aspx.cs" Inherits="PaymentWebApp.StatPlata" %>

<asp:Content ID="StatPlata" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5" id="printableContent">
        <div class="container text-center">
            <div class="mt-5 print-hide">
                <h2>Stat de plată</h2>
            </div>
        </div>
        <div class="text-center mt-3 mb-3 print-hide">
            <asp:Button ID="btnPrintare" runat="server" Text="Tipărire" CssClass="btn btn-primary" OnClientClick="PrintContent();return false;" />
        </div>
        <div class="text-center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" style="margin: auto;">
                <Columns>
                    <asp:TemplateField HeaderText="Poză">
                        <ItemTemplate>
                            <asp:Image ID="imgPoza" runat="server" Height="100px" Width="100px"
                                ImageUrl='<%# "data:image/jpeg;base64," + Convert.ToBase64String((byte[])Eval("poza")) %>'
                                AlternateText="Poza" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="nume" HeaderText="Nume" />
                    <asp:BoundField DataField="prenume" HeaderText="Prenume" />
                    <asp:BoundField DataField="functie" HeaderText="Funcție" />
                    <asp:BoundField DataField="salar_baza" HeaderText="Salariu de bază" />
                    <asp:BoundField DataField="spor" HeaderText="Spor (%)" />
                    <asp:BoundField DataField="premii_brute" HeaderText="Premii brute" />
                    <asp:BoundField DataField="retineri" HeaderText="Rețineri" />
                    <asp:BoundField DataField="virat_card" HeaderText="Virat card" />
                </Columns>
                <RowStyle CssClass="gridview-row" />
            </asp:GridView>
        </div>
    </div>

    <script>
        function PrintContent() {
            var printWindow = window.open('', '_blank');
            printWindow.document.write('<html><head><title>Stat de plată</title>');
            printWindow.document.write('<style>.print-hide { display: none; } .text-center { text-align: center; }</style>');
            printWindow.document.write('</head><body>');
            printWindow.document.write(document.getElementById("printableContent").innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }
    </script>
</asp:Content>
