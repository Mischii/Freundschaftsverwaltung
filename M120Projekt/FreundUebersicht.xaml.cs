using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using M120Projekt.Data;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Freund> freunde = new List<Freund>();
        int freundID = 0;
        public MainWindow()
        {
            InitializeComponent();
            // Wichtig!
            Data.Global.context = new Data.Context();
            // Aufruf diverse APIDemo Methoden
            //APIDemo.FreundDelete();
            APIDemo.FreundCreate();
            APIDemo.FreundCreateKurz();
            APIDemo.FruendRead();
            //APIDemo.FreundUpdate();
            APIDemo.FruendRead();

            alleFreunde.ItemsSource = freunde;
            freunde.AddRange(Freund.LesenAlle());
        }

        private void ProgrammSchliesen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FreundErfassen_Click(object sender, RoutedEventArgs e)
        {
            FreundErstellen freundErstellen = new FreundErstellen();
            freundErstellen.Show();
        }

        private void DetailsAnzeigen(object sender, RoutedEventArgs e)
        {
            Freund freund = (Freund)(sender as Button).DataContext;
            freundID = Convert.ToInt16(freund.FreundID);
            FreundDetailAnsicht freundDetail = new FreundDetailAnsicht(freundID);
            freundDetail.Show();
        }

        private void FreundEditieren(object sender, RoutedEventArgs e)
        {
            Freund freund = (Freund)(sender as Button).DataContext;
            freundID = Convert.ToInt16(freund.FreundID);
            FreundAktualisieren freundAktualisieren = new FreundAktualisieren(freundID);
            freundAktualisieren.Show();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
