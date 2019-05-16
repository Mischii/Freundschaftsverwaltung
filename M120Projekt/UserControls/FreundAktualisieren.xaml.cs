using M120Projekt.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für FreundAktualisieren.xaml
    /// </summary>
    public partial class FreundAktualisieren : UserControl
    {
        ContentControl cc;
        int aktuellerFreund = 0;
        public FreundAktualisieren(ContentControl cc, int freundID)
        {
            InitializeComponent();
            this.cc = cc;
            //setzt die werte für das DropDown
            uBeziehung.Items.Add("");
            uBeziehung.Items.Add("Freund / Freundin");
            uBeziehung.Items.Add("Vater / Mutter");
            uBeziehung.Items.Add("Bruder / Schwester");
            uBeziehung.Items.Add("Verwante");
            uBeziehung.Items.Add("Kollege / Kollegin");

            uGeburtsdatum.DisplayDateEnd = DateTime.Now;
            uBefreundetSeit.DisplayDateEnd = DateTime.Now;

            //Name
            this.iName.SetRegex(@"(^[A-Za-zÖÄÜÈÉöäüèé]{2,}[\s]*[A-Za-zÖÄÜÈÉöäüèé]*$)");
            this.iName.SetFehlerKommentar("min. 2 Buchstaben");
            this.iName.SetKorrekterKommentar("korrekt");
            this.iName.pflichtfeld = true;

            //Vorname
            this.iVorname.SetRegex(@"(^[A-Za-zÖÄÜÈÉöäüèé]{2,}[\s]*[A-Za-zÖÄÜÈÉöäüèé]*$)");
            this.iVorname.SetFehlerKommentar("min. 2 Buchstaben");
            this.iVorname.SetKorrekterKommentar("korrekt");
            this.iVorname.pflichtfeld = true;

            //Adresse
            this.iAdresse.SetRegex(@"(^[A-Za-zÖÄÜÈÉöäüèé]{2,}[\s]*[0-9]*$)");
            this.iAdresse.SetFehlerKommentar("Buchstaben, optional Zahl");
            this.iAdresse.SetKorrekterKommentar("korrekt");
            this.iAdresse.pflichtfeld = true;

            //Plz
            this.iPlz.SetRegex(@"(^[0-9]{4}$)");
            this.iPlz.SetFehlerKommentar("vier Zahlen");
            this.iPlz.SetKorrekterKommentar("korrekt");
            this.iPlz.pflichtfeld = true;

            //Ort
            this.iOrt.SetRegex(@"(^[A-Za-zÖÄÜÈÉöäüèé]{2,}$)");
            this.iOrt.SetFehlerKommentar("min. 2 Buchstaben");
            this.iOrt.SetKorrekterKommentar("korrekt");
            this.iOrt.pflichtfeld = true;

            //Handynummer
            this.iHandynummer.SetRegex(@"(^[+]?[0-9]{0,2}[\s]*[0-9]{1,3}[\s]*[0-9]{1,3}[\s]*[0-9]{1,2}[\s]*[0-9]{1,2}$)");
            this.iHandynummer.SetFehlerKommentar("+, Leerschlag und Zahlen");
            this.iHandynummer.SetKorrekterKommentar("korrekt");

            //Email
            this.iEmail.SetRegex(@"(^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$)");
            this.iEmail.SetFehlerKommentar("gültige E-Mailadresse");
            this.iEmail.SetKorrekterKommentar("korrekt");

            AenderungSpeichern.IsEnabled = false;


            aktuellerFreund = freundID;
            Data.Freund freund = Data.Freund.LesenID(aktuellerFreund);

            iName.SetEingabe(freund.Nachname);
            iVorname.SetEingabe(freund.Vorname);
            iAdresse.SetEingabe(freund.Adresse);
            iPlz.SetEingabe(freund.PLZ.ToString());
            iOrt.SetEingabe(freund.Ort);
            uGeburtsdatum.SelectedDate = freund.Geburtsdatum;
            iHandynummer.SetEingabe(freund.Handynummer);
            iEmail.SetEingabe(freund.Email);
            if (freund.Beziehungsstatus == true)
            {
                uVergeben.IsChecked = true;
                uSingle.IsChecked = false;
            }
            else
            {
                uVergeben.IsChecked = false;
                uSingle.IsChecked = true;
            }
            uBeziehung.Text = freund.Beziehung;
            uBefreundetSeit.SelectedDate = freund.BefreundetSeit;

        }

        private void AenderungSpeichern_Click(object sender, RoutedEventArgs e)
        {
            Data.Freund freund = Data.Freund.LesenID(aktuellerFreund);
            freund.Nachname = iName.GetEingabe();
            freund.Vorname = iVorname.GetEingabe();
            freund.Adresse = iAdresse.GetEingabe();
            freund.PLZ = Convert.ToInt32(iPlz.GetEingabe());
            freund.Ort = iOrt.GetEingabe();
            if (this.uGeburtsdatum.SelectedDate != null)
            {
                freund.Geburtsdatum = Convert.ToDateTime(uGeburtsdatum.SelectedDate.Value);
            }
            freund.Handynummer = iHandynummer.GetEingabe();
            freund.Email = iEmail.GetEingabe();
            if (uVergeben.IsChecked == true)
            {
                freund.Beziehungsstatus = true;
            }
            else
            {
                freund.Beziehungsstatus = false;
            }
            freund.Beziehung = Convert.ToString(uBeziehung.SelectedValue);
            if (this.uBefreundetSeit.SelectedDate != null)
            {
                freund.BefreundetSeit = Convert.ToDateTime(uBefreundetSeit.SelectedDate.Value);
            }

            freund.Aktualisieren();
            MessageBox.Show("Änderungen wurde erfolgreich gespeichert",
                "Gespeicheert",
                MessageBoxButton.OK,
                MessageBoxImage.Asterisk);
            cc.Content = new AlleFreunde(cc);
        }

        private void UberpruefeValidierung(object sender, RoutedEventArgs e)
        {
            if (this.iVorname.Ueberpruefung() && this.iName.Ueberpruefung() && this.iAdresse.Ueberpruefung()
                && this.iPlz.Ueberpruefung() && this.iOrt.Ueberpruefung())
            {
                if (this.iHandynummer.GetEingabe() != "")
                {
                    AenderungSpeichern.IsEnabled = this.iHandynummer.Ueberpruefung();
                }
                else
                {
                    AenderungSpeichern.IsEnabled = true;
                }
                if (this.iEmail.GetEingabe() != "")
                {
                    AenderungSpeichern.IsEnabled = this.iEmail.Ueberpruefung();
                }
                else
                {
                    AenderungSpeichern.IsEnabled = true;
                }
                if ((this.uGeburtsdatum.SelectedDate != null && this.uGeburtsdatum.SelectedDate > DateTime.Now)
                    || (this.uBefreundetSeit.SelectedDate != null && this.uBefreundetSeit.SelectedDate > DateTime.Now))
                {
                    AenderungSpeichern.IsEnabled = false;
                }
                else
                {
                    AenderungSpeichern.IsEnabled = true;
                }
            }
            else
            {
                AenderungSpeichern.IsEnabled = false;
            }
        }

        private void freundLoeschen_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ergebnis = MessageBox.Show("Wollen Sie diesen Freund wirklich löschen?",
                    "Löschen",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

            if (ergebnis == MessageBoxResult.Yes)
            {
                Data.Freund.LesenID(aktuellerFreund).Loeschen();
                cc.Content = new AlleFreunde(cc);
            }
            
        }

        private void abbrechen_Click(object sender, RoutedEventArgs e)
        {
            cc.Content = new AlleFreunde(cc);
        }
    }
}
