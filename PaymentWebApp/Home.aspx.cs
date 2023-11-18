using System;
using System.IO;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace PaymentWebApp
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCreateTables_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                byte[] poza1, poza2, poza3, poza4, poza5, poza6, poza7, poza8, poza9, poza10;


                using (System.IO.FileStream fs1 = new System.IO.FileStream(Server.MapPath("/MockPhotos/Poza1.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br1 = new System.IO.BinaryReader(fs1))
                    {
                        poza1 = br1.ReadBytes((int)fs1.Length);
                    }
                }
                using (System.IO.FileStream fs2 = new System.IO.FileStream(Server.MapPath("/MockPhotos/Poza2.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br2 = new System.IO.BinaryReader(fs2))
                    {
                        poza2 = br2.ReadBytes((int)fs2.Length);
                    }
                }
                using (System.IO.FileStream fs3 = new System.IO.FileStream(Server.MapPath("/MockPhotos/Poza3.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br3 = new System.IO.BinaryReader(fs3))
                    {
                        poza3 = br3.ReadBytes((int)fs3.Length);
                    }
                }
                using (System.IO.FileStream fs4 = new System.IO.FileStream(Server.MapPath("/MockPhotos/Poza4.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br4 = new System.IO.BinaryReader(fs4))
                    {
                        poza4 = br4.ReadBytes((int)fs4.Length);
                    }
                }
                using (System.IO.FileStream fs5 = new System.IO.FileStream(Server.MapPath("/MockPhotos/Poza5.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br5 = new System.IO.BinaryReader(fs5))
                    {
                        poza5 = br5.ReadBytes((int)fs5.Length);
                    }
                }
                using (System.IO.FileStream fs6 = new System.IO.FileStream(Server.MapPath("/MockPhotos/Poza6.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br6 = new System.IO.BinaryReader(fs6))
                    {
                        poza6 = br6.ReadBytes((int)fs6.Length);
                    }
                }
                using (System.IO.FileStream fs7 = new System.IO.FileStream(Server.MapPath("/MockPhotos/Poza7.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br7 = new System.IO.BinaryReader(fs7))
                    {
                        poza7 = br7.ReadBytes((int)fs7.Length);
                    }
                }
                using (System.IO.FileStream fs8 = new System.IO.FileStream(Server.MapPath("/MockPhotos/Poza8.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br8 = new System.IO.BinaryReader(fs8))
                    {
                        poza8 = br8.ReadBytes((int)fs8.Length);
                    }
                }
                using (System.IO.FileStream fs9 = new System.IO.FileStream(Server.MapPath("/MockPhotos/Poza9.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br9 = new System.IO.BinaryReader(fs9))
                    {
                        poza9 = br9.ReadBytes((int)fs9.Length);
                    }
                }
                using (System.IO.FileStream fs10 = new System.IO.FileStream(Server.MapPath("~/MockPhotos/Poza10.png"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader br10 = new System.IO.BinaryReader(fs10))
                    {
                        poza10 = br10.ReadBytes((int)fs10.Length);
                    }
                }

                string createTablesTriggers = @"
                        -- SQL command to create 'gestiune' table if it doesn't exist
            CREATE TABLE IF NOT EXISTS `angajati`.`gestiune` (
             `nr_crt` INT NOT NULL AUTO_INCREMENT,
             `nume` VARCHAR(45) NOT NULL,
  `prenume` VARCHAR(45) NOT NULL,
  `functie` VARCHAR(45) NOT NULL,
  `salar_baza` INT NOT NULL,
  `spor` INT NULL DEFAULT 0,
  `premii_brute` INT NULL DEFAULT 0,
  `total_brut` INT GENERATED ALWAYS AS (salar_baza * (1 + (spor / 100)) + premii_brute),
  `procente_id` INT,
  `cas_procent_val` FLOAT,
  `cass_procent_val` FLOAT,
  `impozit_procent_val` FLOAT,
  `brut_impozabil` INT GENERATED ALWAYS AS (total_brut - (total_brut * cas_procent_val) - (total_brut * cass_procent_val)) VIRTUAL,
  `cas` INT GENERATED ALWAYS AS (total_brut * cas_procent_val) VIRTUAL,
  `cass` INT GENERATED ALWAYS AS (total_brut * cass_procent_val) VIRTUAL,
  `impozit` INT GENERATED ALWAYS AS (brut_impozabil * impozit_procent_val) VIRTUAL,
  `retineri` INT NULL DEFAULT 0,
  `virat_card` INT GENERATED ALWAYS AS (total_brut - impozit - (total_brut * cas_procent_val) - (total_brut * cass_procent_val) - retineri),
  `poza` LONGBLOB NULL,
  PRIMARY KEY (`nr_crt`)
);

-- Delete existing data from 'gestiune' table
DELETE FROM `angajati`.`gestiune`;

-- SQL command to create 'procente' table if it doesn't exist
CREATE TABLE IF NOT EXISTS `angajati`.`procente` (
  `cas_procent` float NOT NULL DEFAULT '0.25',
  `cass_procent` float NOT NULL DEFAULT '0.1',
  `impozit_procent` float NOT NULL DEFAULT '0.1',
  `id` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id`)
);

-- SQL command to insert data into 'gestiune' table
INSERT INTO `angajati`.`gestiune` (`nume`, `prenume`, `functie`, `salar_baza`, `spor`, `premii_brute`, `procente_id`, `retineri`, `poza`)
VALUES ('Pacurariu', 'Adrian', 'Developer', 11000, 10, 750, 1, 0, @Poza1),
 ('Cooper', 'Sara', 'Manager', 18300, 20, 1000, 1, 200, @Poza2),
 ('Badea', 'Adrian', 'Tester', 8800, 0, 250, 1, 0, @Poza3),
 ('Pop', 'Gabriel', 'Product Owner', 15000, 10, 500, 1, 0, @Poza4),
 ('Andreea', 'Madalina', 'HR Recruiter', 9000, 0, 300, 1, 300, @Poza5),
 ('Popa', 'Mircea', 'Engineer', 13490, 20, 1000, 1, 0, @Poza6),
 ('Popa', 'Claudia', 'Analyst', 7950, 0, 200, 1, 0, @Poza7),
 ('Pop', 'Anastasia', 'OP Recruiter', 20000, 0, 0, 1, 0, @Poza8),
 ('Larsson', 'Emil', 'Team Leader', 21500, 0, 1500, 1, 1300, @Poza9),
 ('Cicu', 'Anca', 'Purchaser', 6000, 0, 0, 1, 0, @Poza10);

-- SQL command to create 'before_insert_gestiune' trigger if it doesn't exist
    DROP TRIGGER IF EXISTS before_insert_gestiune;
    CREATE TRIGGER before_insert_gestiune 
    BEFORE INSERT ON `angajati`.`gestiune` 
    FOR EACH ROW 
    BEGIN
       SET NEW.procente_id = 1;
       SET NEW.cas_procent_val = (SELECT cas_procent FROM `angajati`.`procente` WHERE `id` = NEW.procente_id);
       SET NEW.cass_procent_val = (SELECT cass_procent FROM `angajati`.`procente` WHERE `id` = NEW.procente_id);
       SET NEW.impozit_procent_val = (SELECT impozit_procent FROM `angajati`.`procente` WHERE `id` = NEW.procente_id);
    END";
      

                using (MySqlCommand cmd = new MySqlCommand(createTablesTriggers, conn))
                {
                    cmd.Parameters.AddWithValue("@Poza1", poza1);
                    cmd.Parameters.AddWithValue("@Poza2", poza2);
                    cmd.Parameters.AddWithValue("@Poza3", poza3);
                    cmd.Parameters.AddWithValue("@Poza4", poza4);
                    cmd.Parameters.AddWithValue("@Poza5", poza5);
                    cmd.Parameters.AddWithValue("@Poza6", poza6);
                    cmd.Parameters.AddWithValue("@Poza7", poza7);
                    cmd.Parameters.AddWithValue("@Poza8", poza8);
                    cmd.Parameters.AddWithValue("@Poza9", poza9);
                    cmd.Parameters.AddWithValue("@Poza10", poza10);
                    cmd.ExecuteNonQuery();
                }
            }
            string successMessage = "Datele au fost incarcate cu succes!";
            Session["SuccessMessage"] = successMessage;
            Response.Redirect("StatPlata.aspx?success=true");
        }
    }
}