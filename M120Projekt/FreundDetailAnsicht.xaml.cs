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
    /// Interaktionslogik für FreundDetailAnsicht.xaml
    /// </summary>
    public partial class FreundDetailAnsicht : Window
    {
        int aktuellerFreund = 0;
        public FreundDetailAnsicht(int freundID)
        {
            InitializeComponent();
            aktuellerFreund = freundID;

            Data.Freund freund = Data.Freund.LesenID(aktuellerFreund);

            uName.Content = freund.Nachname;
            uVorname.Content = freund.Vorname;
            uAdresse.Content = freund.Adresse;
            uPlz.Content = freund.PLZ.ToString();
            uOrt.Content = freund.Ort;
            uGeburtsdatum.Content = freund.Geburtsdatum.ToString("dd.MM.yyyy");
            uHandynummer.Content = freund.Handynummer;
            uEmail.Content = freund.Email;
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
            uBeziehung.Content = freund.Beziehung;
            uBefreundetSeit.Content = freund.BefreundetSeit.ToString("dd.MM.yyyy");
        }

        private void Schliesen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FreundLoeschen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Der Freund wurde unwiederruflich gelöscht", 
                "Gelöscht", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            Data.Freund.LesenID(aktuellerFreund).Loeschen();
            this.Close();
        }
    }
}
