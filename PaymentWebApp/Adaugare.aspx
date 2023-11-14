<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Adaugare.aspx.cs" Inherits="PaymentWebApp.Adaugare" %>

<asp:Content ID="Adaugare" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container text-center">
        <div class="mt-5">
            <h2>Adăugare angajat în gestiune</h2>
            <br />
            <form>
                <div class="row">
                    <div class="col-md-6 offset-md-3">
                        <div class="form-group">
                            <label for="nume">Nume</label>
                            <input type="text" class="form-control" id="nume" name="nume" placeholder="Introduceți numele">
                        </div>
                        <div class="form-group">
                            <label for="prenume">Prenume</label>
                            <input type="text" class="form-control" id="prenume" name="prenume" placeholder="Introduceți prenumele">
                        </div>
                        <div class="form-group">
                            <label for="functie">Funcție</label>
                            <input type="text" class="form-control" id="functie" name="functie" placeholder="Introduceți funcția">
                        </div>
                        <div class="form-group">
                            <label for="salar">Salariu de bază</label>
                            <input type="text" class="form-control" id="salar" name="salar" placeholder="Introduceți salariul de bază">
                        </div>
                        <div class="form-group">
                            <label for="spor">Spor (%)</label>
                            <input type="text" class="form-control" id="spor" name="spor" placeholder="Introduceți sporul în procente">
                        </div>
                        <div class="form-group">
                            <label for="premii">Premii brute</label>
                            <input type="text" class="form-control" id="premii" name="premii" placeholder="Introduceți valoarea premiilor brute">
                        </div>
                        <div class="form-group">
                            <label for="retineri">Rețineri</label>
                            <input type="text" class="form-control" id="retineri" name="retineri" placeholder="Introduceți valoarea reținerilor">
                        </div>
                        <div class="form-group">
                            <label for="poza">Poza</label><br />
                            <input type="file" class="form-control-file" id="poza" name="poza" accept=".jpeg, .jpg, .png" runat="server">
                        </div>
                        <br />
                        <asp:Button ID="btnAdaugare" runat="server" Text="Adăugare" OnClick="AdaugaAngajat" CssClass="btn btn-primary" />
                    </div>
                </div>
            </form>
        </div>
    </div>  
</asp:Content>