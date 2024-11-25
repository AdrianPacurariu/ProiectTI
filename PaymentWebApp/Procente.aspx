﻿<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Procente.aspx.cs" Inherits="PaymentWebApp.Procente" %>

<asp:Content ID="Procente" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="container text-center">
            <div class="mt-5">
                <h2>Modificare procente salarizare</h2>
            </div>
        </div>
        <br />
        <br />
        <center>
            <asp:Label ID="InfoLabel" runat="server" Text="Zonă protejată: Pentru a modifica valorile procentuale ale grilei de salarizare, introduceți parola."></asp:Label>
            <br />
            <asp:Panel ID="LoginPanel" runat="server">
                <asp:TextBox ID="PasswordTextbox" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="LoginButton" runat="server" Text="Autentificare" OnClick="LoginButton_Click" />
                <br />
                <br />
                <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" Visible="false"></asp:Label>

            </asp:Panel>
            <br />
            <br />

            <asp:Panel ID="DataPanel" runat="server" Visible="false">
                <asp:GridView ID="ProcenteGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowDataBound="ProcenteGridView_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="cas_procent" HeaderText="CAS (%)" />
                        <asp:BoundField DataField="cass_procent" HeaderText="CASS (%)" />
                        <asp:BoundField DataField="impozit_procent" HeaderText="Impozit (%)" />
                    </Columns>
                    <RowStyle CssClass="gridview-row" />
                </asp:GridView>
                <br />
                <asp:Button ID="BackButton" runat="server" Text="Înapoi" OnClick="BackButton_Click" />
                <asp:Button ID="ChangePasswordButton" runat="server" Text="Schimbare parolă" OnClientClick="changePassword();" />

            </asp:Panel>
        </center>
    </div>

    <script type="text/javascript">
        function changePassword() {
            var newPassword = prompt("Introduceți noua parolă:", "");
            if (newPassword != null && newPassword != "") {
                var confirmPassword = prompt("Confirmați noua parolă:", "");
                if (confirmPassword != null && confirmPassword != "") {
                    if (newPassword === confirmPassword) {
                        $.ajax({
                            type: "POST",
                            url: "Procente.aspx/ChangePassword",
                            data: JSON.stringify({ newPassword: newPassword }),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                alert(response.d);
                            },
                            error: function (error) {
                                alert("A apărut o eroare în timpul schimbării parolei: " + error.responseText);
                            }
                        });
                    } else {
                        alert("Parolele nu se potrivesc. Vă rugăm să încercați din nou.");
                    }
                } else {
                    alert("Parola nu a fost confirmată.");
                }
            } else {
                alert("Parola nu a fost introdusă.");
            }
        }

        function editCell(linkElement, columnName, columnIndex) {
            var cell = linkElement.parentNode;
            var row = cell.parentNode;

            var originalValue = cell.innerText.split(' - ')[0];
            var newValue = prompt("Introduceți noua valoare:");

            if (newValue !== null) {
                var floatValue = parseFloat(newValue);
                if (!isNaN(floatValue) && floatValue >= 0 && floatValue <= 100) {
                    var columnIndex = Array.prototype.indexOf.call(row.children, cell);
                    row.cells[columnIndex].innerText = floatValue + '%';

                    var url = 'Procente.aspx/UpdateProcenteValue';
                    var data = JSON.stringify({ columnName: columnName, newValue: floatValue });

                    fetch(url, {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: data
                    })
                        .then(response => response.json())
                        .then(result => {
                            alert(result.d);
                            window.location.reload();
                        })
                        .catch(error => alert("A apărut o eroare în timpul actualizării valorii: " + error));
                } else {
                    alert("Vă rugăm să introduceți o valoare numerică validă între 0 și 100.");
                }
            }
        }
    </script>
</asp:Content>
