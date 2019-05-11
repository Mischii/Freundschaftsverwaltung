using M120Projekt.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M120Projekt.UserControls
{
    /// <summary>
    /// Interaktionslogik für AlleFreunde.xaml
    /// </summary>
    /// 
    
    public partial class AlleFreunde : UserControl
    {
        ContentControl cc;
        List<Freund> freunde = new List<Freund>();
        int freundID = 0;
        public AlleFreunde(ContentControl cc)
        {
            InitializeComponent();
            alleFreunde.ItemsSource = freunde;
            freunde.AddRange(Freund.LesenAlle());
            this.cc = cc;
        }
        
        private void FreundErfassen_Click(object sender, RoutedEventArgs e)
        {
            cc.Content = new FreundErstellen(cc);
        }

        private void FreundEditieren(object sender, RoutedEventArgs e)
        {
            Freund freund = (Freund)(sender as TextBlock).DataContext;
            freundID = Convert.ToInt16(freund.FreundID);

            cc.Content = new FreundAktualisieren(cc,freundID);
        }
    }
}
