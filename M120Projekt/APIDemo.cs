using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt
{
    static class APIDemo
    {
        #region Freund
        // Create
        public static void FreundCreate()
        {
            Debug.Print("--- FreundCreate ---");
            // KlasseA
            Data.Freund freund1 = new Data.Freund();
            freund1.Vorname = "Lisa";
            freund1.Nachname = "Friedli";
            freund1.Adresse = "Blummenweg 5";
            freund1.PLZ = 3366;
            freund1.Ort = "Bettenhausen";
            freund1.Geburtsdatum = new DateTime(1998,07,12);
            freund1.Handynummer = "079 878 99 88";
            freund1.Email = "lisa.friedlic@gamil.com";
            freund1.Beziehungsstatus = false;
            freund1.Beziehung = "Freund / Freundin";
            freund1.BefreundetSeit = new DateTime(2011,09,15);
            Int64 freund1Id = freund1.Erstellen();
            Debug.Print("Freund erstellt mit Id:" + freund1Id);
        }
        public static void FreundCreateKurz()
        {
            Data.Freund freund2 = new Data.Freund { Vorname = "Tim", Nachname = "Sutter", Adresse = "Poststrasse 11",
                   PLZ = 3000, Ort = "Bern", Geburtsdatum = DateTime.Today,  Beziehungsstatus = true};
            Int64 freund2Id = freund2.Erstellen();
            Debug.Print("Freund erstellt mit Id:" + freund2Id);
        }

        // Read
        public static void FruendRead()
        {
            Debug.Print("--- FreundRead ---");
            // Demo liest alle
            foreach (Data.Freund freund in Data.Freund.LesenAlle())
            {
                Debug.Print("Freund Id:" + freund.FreundID + " Name:" + freund.Vorname);
            }
        }
        // Update
        public static void FreundUpdate()
        {
            Debug.Print("--- FreundUpdate ---");
            // KlasseA ändert Attribute
            Data.Freund freund = Data.Freund.LesenID(1);
            freund.Ort = "Freund 1 nach Update";
            freund.Aktualisieren();
        }
        // Delete
        public static void FreundDelete()
        {
            Debug.Print("--- FreundDelete ---");
            Data.Freund.LesenID(1).Loeschen();
            Debug.Print("Freund mit Id 1 gelöscht");
        }
        #endregion
    }
}
