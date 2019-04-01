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
    /// Interaktionslogik für FreundErstellen.xaml
    /// </summary>
    public partial class FreundErstellen : Window
    {
        public FreundErstellen()
        {
            InitializeComponent();
            //setzt die werte für das DropDown
            iBeziehung.Items.Add("Freund / Freundin");
            iBeziehung.Items.Add("Vater / Mutter");
            iBeziehung.Items.Add("Bruder / Schwester");
            iBeziehung.Items.Add("Verwante");
            iBeziehung.Items.Add("Kollege / Kollegin");

            //Name
            this.iName.SetRegex(@"(^[A-Za-zÖÄÜÈÉöäüèé]{2,}$)");
            this.iName.SetFehlerKommentar("min. 2 Buchstaben");
            this.iName.SetKorrekterKommentar("korrekt");
            this.iName.pflichtfeld = true;

            //Vorname
            this.iVorname.SetRegex(@"(^[A-Za-zÖÄÜÈÉöäüèé]{2,}$)");
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
            this.iHandynummer.SetRegex(@"(^[+]?[0-9]{0,3}[\s]*[0-9]{1,3}[\s]*[0-9]{1,3}[\s]*[0-9]{1,2}[\s]*[0-9]{1,2}$)");
            this.iHandynummer.SetFehlerKommentar("+, Leerschlag und Zahlen");
            this.iHandynummer.SetKorrekterKommentar("korrekt");

            //Email
            this.iEmail.SetRegex(@"(^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$)");
            this.iEmail.SetFehlerKommentar("gültige E-Mailadresse");
            this.iEmail.SetKorrekterKommentar("korrekt");

        }

        private void Abbrechen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FreundSpeichern_Click(object sender, RoutedEventArgs e)
        {
            //save
            this.Close();
        }
    }
}
