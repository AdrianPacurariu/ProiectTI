<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PaymentWebApp.Home" %>

<asp:Content ID="Info" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="text-align: left mt-5">
            <h4>Bine ați venit.
                <br />
                Această aplicație realizează calculul salariilor dintr-o firmă și gestionarea datelor despre angajați.</h4>
            <br />
            <p>OPȚIUNILE APLICAȚIEI SUNT:</p>
            <ol>
                <li style="font-weight: bold">ADĂUGARE / ȘTERGERE / MODIFICARE DATE ANGAJAT</li>
                <span>Pentru a ADĂUGA, ȘTERGE sau pentru a MODIFICA datele unui angajat, faceți click pe butonul "Introducere date" și selectați opțiunea dorită.
                            <br />
                    Acolo veți găsi trei butoane cu nume specifice, iar prin apăsarea oricărui buton, veți fi redirecționat către alte ferestre.
                        <br />
                    - Fereastra "Actualizare date" conține un tabel unde apar datele despre angațați, o căsuță unde puteți căuta un angajat dupa nume și/sau prenume și alte două butoane pentru renunțarea / salvarea modificărilor. Pentru a modifica datele despe un angajat, pe tabel, puteți selecta coloana pe care doriți să o modificați, tastați modificarea și apoi apăsați butonul "Salvare modificări". Pentru renunțarea la modifi-
cări, dacă ați introdus un text greșit sau v-ați răzgandit, puteți apăsa pe butonul "Renunțare la modificări". 
                        <br />
                    - Fereastra "Adăugare" conține căsuțe de text unde puteți introduce datele despre noul angajat, iar salariul se va calcula pe baza a ceea ce scrieți în câmpurile "Salar de bază", "Premii brute", "Spor", "Rețineri".
                        <br />
                    - Fereastra "Ștergere" conține o căsuță text unde puteți căuta un angajat dupa nume și/sau prenume, iar acesta va apărea în tabelul de mai sus sau, dacă sunt mai multe persoane cu același nume și/sau prenume, vor apărea toate acele persoane. În tabel, vă puteți plimba cu mouse-ul sau din săgeți și, dacă doriți ștergrea unei anumite persoane, selectați numele persoanei și apăsați pe butonul de ștergere care va afișa un mesaj de asigurare. În urma ștergerii, se va afișa alt mesaj pentru confirmare.
                    <br />
                </span>
                <br />
                <li style="font-weight: bold">STAT DE PLATĂ / FLUTURAȘI ANGAJAȚI SUB FORMĂ DE RAPOARTE</li>
                <span>Pentru a vizualiza raportul cu statul de plată, respectiv cu fluturașii angajaților, faceți click pe butonul "Rapoarte" și selectați opțiunea dorită.
                        <br />
                    - Fereastra "Stat de plată" conține raportul cu datele angaților și totalul anumitor câmpuri. 
                        <br />
                    - Fereastra "Fluturași" conține raportul cu fluturașul de salariu pentru fiecare angajat.
                    <br />
                </span>
                <br />
                <li style="font-weight: bold">MODIFICARE PROCENTE SALARIZARE</li>
                <span>- Fereastra "Procente" permite modificarea procentelor din grila de salarizare.
                </span>
            </ol>
        </div>

        <div class="text-center mt-4">
            <asp:Button ID="btnCreateTables" runat="server" Text="Creare și populare tabele" CssClass="btn btn-primary" OnClick="btnCreateTables_Click" />
        </div>
    </div>
</asp:Content>
