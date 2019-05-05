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
    public partial class FreundAktualisieren : Window
    {
        int aktuellerFreund = 0;
        public FreundAktualisieren(int freundID)
        {
            InitializeComponent();
            //setzt die werte für das DropDown
            uBeziehung.Items.Add("");
            uBeziehung.Items.Add("Freund / Freundin");
            uBeziehung.Items.Add("Vater / Mutter");
            uBeziehung.Items.Add("Bruder / Schwester");
            uBeziehung.Items.Add("Verwante");
            uBeziehung.Items.Add("Kollege / Kollegin");

            aktuellerFreund = freundID;
            Data.Freund freund = Data.Freund.LesenID(aktuellerFreund);

            uName.Text = freund.Nachname;
            uVorname.Text = freund.Vorname;
            uAdresse.Text = freund.Adresse;
            uPlz.Text = freund.PLZ.ToString();
            uOrt.Text = freund.Ort;
            uGeburtsdatum.Text = freund.Geburtsdatum.ToString();
            uHandynummer.Text = freund.Handynummer;
            uEmail.Text = freund.Email;
            if(freund.Beziehungsstatus == true)
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
            uBefreundetSeit.Text = freund.BefreundetSeit.ToString();

        }

        private void Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Das Erstellen wurde abgebrochen",
                "Abbrechen",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
            this.Close();
        }

        private void AenderungSpeichern_Click(object sender, RoutedEventArgs e)
        {
            Data.Freund freund = Data.Freund.LesenID(aktuellerFreund);

            freund.Nachname = uName.Text;
            freund.Vorname = uVorname.Text;
            freund.Adresse = uAdresse.Text;
            freund.PLZ = Convert.ToInt32(uPlz.Text);
            freund.Ort = uOrt.Text;
            if (this.uGeburtsdatum.SelectedDate != null)
            {
                freund.Geburtsdatum = Convert.ToDateTime(uGeburtsdatum.SelectedDate.Value);
            }
            freund.Handynummer = uHandynummer.Text;
            freund.Email = uEmail.Text;
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
            this.Close();
        }
    }
}
