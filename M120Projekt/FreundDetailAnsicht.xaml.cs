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
        public FreundDetailAnsicht()
        {
            InitializeComponent();
        }

        private void ProgrammSchliesen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FreundErfassen_Click(object sender, RoutedEventArgs e)
        {
            //freund aus db löschen
            this.Close();
        }
    }
}
