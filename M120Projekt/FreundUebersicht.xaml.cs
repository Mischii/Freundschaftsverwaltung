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

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Wichtig!
            Data.Global.context = new Data.Context();
            // Aufruf diverse APIDemo Methoden
            APIDemo.FreundCreate();
            APIDemo.FreundCreateKurz();
            APIDemo.FruendRead();
            APIDemo.FreundUpdate();
            APIDemo.FruendRead();
            //APIDemo.FreundDelete();
        }

        private void ProgrammSchliesen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FreundErfassen_Click(object sender, RoutedEventArgs e)
        {
            //FreundErstellen freundErstellen = new FreundErstellen();
            //freundErstellen.Show();
        }
    }
}
