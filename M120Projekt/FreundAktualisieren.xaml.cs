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
        public FreundAktualisieren()
        {
            InitializeComponent();
            //setzt die werte für das DropDown
            uBeziehung.Items.Add("Freund / Freundin");
            uBeziehung.Items.Add("Vater / Mutter");
            uBeziehung.Items.Add("Bruder / Schwester");
            uBeziehung.Items.Add("Verwante");
            uBeziehung.Items.Add("Kollege / Kollegin");
        }
    }
}
