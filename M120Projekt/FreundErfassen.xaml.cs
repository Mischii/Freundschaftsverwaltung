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


            this.iName.SetRegex(@"([A-Za-zÖÄÜÈÉöäüèé]{2,})");
            this.iName.SetFehlerKommentar("Buchstaben min. 2");
            this.iName.SetKorrekterKommentar("korrekt");

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
