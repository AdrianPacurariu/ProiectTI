<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="PaymentWebApp.HomePage" %>

<!DOCTYPE html>

<html>
<head>
<title>Proiect ASP.NET - Aplicatie Salarizare</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <link href="css/styles.css" rel="stylesheet" />
    <link rel="icon" type="image/x-icon" href="assets/favicon.ico" />
    </head>
<body>
    <form id="HomePage" runat="server">
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="navbar-header text-center">
          <a class="navbar-brand mb-0 h1 mx-auto d-block">Proiect ASP.NET Aplicație Salarizare - PĂCURARIU Rareș-Adrian</a>
            <br /><br />
            <div style="display: flex; justify-content: space-between; color: white; margin: 0 10px;">
            <div style="display: flex; align-items: center;">
                <p id="date"></p>
            </div>
            <div style="display: flex; align-items: center; margin-left: auto;">
                <img src="" id="firstPic" style="width: 100px; height: 100px; border: 1px solid white; margin: 0 20px;" />
                <img src="" id="secondPic" style="width: 100px; height: 100px; border: 1px solid white; margin: 0 20px;" />
            </div>
        </div>
        
        
        <script>
            document.addEventListener("DOMContentLoaded", function () {
                let getRandomImage = () => {
                    var images = new Array(
                        "assets/1.jpg",
                        "assets/2.jpg",
                        "assets/3.jpg"
                    );

                    var first = Math.floor(Math.random() * images.length);
                    var second = Math.floor(Math.random() * images.length);

                    if (first === second) {
                        return getRandomImage();
                    }

                    document.getElementById("firstPic").src = images[first];
                    document.getElementById("secondPic").src = images[second];
                };

                getRandomImage();

                const updateDateTime = () => {
                    const now = new Date();
                    const currentDateTime = now.toLocaleString();
                    document.getElementById("date").innerHTML = currentDateTime;
                };

                setInterval(updateDateTime, 1);
            });
        </script>
        <br />
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto mb-2 mb-lg-0">
                <li class="nav-item"><a class="nav-link active" aria-current="page" href="#">Home</a></li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Introducere date</a>
                    <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="navbarDropdown">
                        <li><a class="dropdown-item" href="#">Actualizare date</a></li>
                        <li><a class="dropdown-item" href="#">Adăugare</a></li>
                        <li><a class="dropdown-item" href="#">Ștergere</a></li>
                        <li><hr class="dropdown-divider" /></li>
                        <li><a class="dropdown-item" href="#">Calcul (dacă este cazul)</a></li>
                    </ul>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Rapoarte</a>
                    <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="navbarDropdown">
                        <li><a class="dropdown-item" href="#">Stat de plată</a></li>
                        <li><a class="dropdown-item" href="#">Fluturași</a></li>
                    </ul>
                </li>    
                <li class="nav-item"><a class="nav-link active" aria-current="page" href="#">Procente</a></li>
            </ul>
        </div>
    </div>
    </nav>


        <!-- Content-->
        <div class="container">
            <div class="text-align: left mt-5">
                <h4>Bine ați venit. <br />Această aplicație realizează calculul salariilor dintr-o firmă și gestionarea datelor despre angajați.</h4>
                <br /><p>OPȚIUNILE APLICAȚIEI SUNT:</p>
                <ol>
                    <li style="font-weight: bold">ADĂUGARE / ȘTERGERE / MODIFICARE DATE ANGAJAT</li>
                    <span>Pentru a ADĂUGA, ȘTERGE sau pentru a MODIFICA datele unui angajat, faceți click pe butonul "Introducere date" și selectați opțiunea dorită.
                            <br />Acolo veți găsi trei butoane cu nume specifice, iar prin apăsarea oricărui buton, veți fi redirecționat către alte ferestre.
                        <br />- Fereastra "Actualizare date" conține un tabel unde apar datele despre angațați, o căsuță unde puteți căuta un angajat dupa nume și/sau prenume și alte două butoane pentru renunțarea / salvarea modificărilor. Pentru a modifica datele despe un angajat, pe tabel, puteți selecta coloana pe care doriți să o modificați, tastați modificarea și apoi apăsați butonul "Salvare modificări". Pentru renunțarea la modifi-
cări, dacă ați introdus un text greșit sau v-ați răzgandit, puteți apăsa pe butonul "Renunțare la modificări". 
                        <br />- Fereastra "Adăugare" conține căsuțe de text unde puteți introduce datele despre noul angajat, iar salariul se va calcula pe baza a ceea ce scrieți în câmpurile "Salar de bază", "Premii brute", "Spor", "Rețineri".
                        <br />- Fereastra "Ștergere" conține o căsuță text unde puteți căuta un angajat dupa nume și/sau prenume, iar acesta va apărea în tabelul de mai sus sau, dacă sunt mai multe persoane cu același nume și/sau prenume, vor apărea toate acele persoane. În tabel, vă puteți plimba cu mouse-ul sau din săgeți și, dacă doriți ștergrea unei anumite persoane, selectați numele persoanei și apăsați pe butonul de ștergere care va afișa un mesaj de asigurare. În urma ștergerii, se va afișa alt mesaj pentru confirmare. <br />
                    </span>
                    <br /><li style="font-weight: bold">STAT DE PLATĂ / FLUTURAȘI ANGAJAȚI SUB FORMĂ DE RAPOARTE</li>
                    <span>Pentru a vizualiza raportul cu statul de plată, respectiv cu fluturașii angajaților, faceți click pe butonul "Rapoarte" și selectați opțiunea dorită.
                        <br />- Fereastra "Stat de plată" conține raportul cu datele angaților și totalul anumitor câmpuri. 
                        <br />- Fereastra "Fluturași" conține raportul cu fluturașul de salariu pentru fiecare angajat. <br />
                    </span>
                    <br /><li style="font-weight: bold">MODIFICARE PROCENTE SALARIZARE</li>
                    <span>
                        - Fereastra "Procente" permite modificarea procentelor din grila de salarizare.
                    </span>
                </ol>
            </div>
        </div>
        <!-- Bootstrap core JS-->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
    </form>
</body>
</html>
