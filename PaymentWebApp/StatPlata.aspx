<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="StatPlata.aspx.cs" Inherits="PaymentWebApp.StatPlata" %>

<asp:Content ID="StatPlata" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5" id="printableContent">
        <style>
            @media print {
                .print-align-right {
                    float: right;
                }

                .right-align-print {
                    text-align: right !important;
                }


                .print-order-first {
                    order: -1;
                }

                .total-label {
                    text-align: right;
                    float: right;
                    clear: both;
                }

                @page {
                    size: 297mm 420mm; /*A3*/
                }
            }
        </style>
        <div class="container text-center">
            <div class="mt-5 print-hide">
                <h2>Stat de plată</h2>
            </div>
        </div>
        <br />
        <div class="row justify-content-end mb-3">
            <div class="col-auto">
                <asp:Label ID="lblCurrentDate" runat="server" Text="Data: " CssClass="print-align-right">"></asp:Label>
            </div>
        </div>
        <br />
        <div class="text-center mt-3 mb-3 print-hide">
            <asp:Button ID="btnPrintare" runat="server" Text="Tipărire" CssClass="btn btn-primary" OnClientClick="PrintContent();return false;" />
        </div>
        <div class="text-center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" Style="margin: auto;">
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
            <br />
            <div class="row justify-content-end mt-3 right-align-print">
                <div class="col-auto">
                    <asp:Label ID="lblTotalSalarBaza" runat="server" Text="Salariile de baza insumeaza: "></asp:Label>
                </div>
            </div>

            <div class="row justify-content-end mt-3 right-align-print">
                <div class="col-auto">
                    <asp:Label ID="lblTotalViratCard" runat="server" Text="Sumele virate pe card insumeaza: "></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <script>
        function displayCurrentDate() {
            var today = new Date();
            var dd = String(today.getDate()).padStart(2, '0');
            var mm = String(today.getMonth() + 1).padStart(2, '0'); // January is 0!
            var yyyy = today.getFullYear();

            var currentDate = dd + '/' + mm + '/' + yyyy;
            document.getElementById('MainContent_lblCurrentDate').innerText = 'Data: ' + currentDate;
        }

        // Call the function to display the current date when the page loads
        window.onload = function () {
            displayCurrentDate();
        };

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
