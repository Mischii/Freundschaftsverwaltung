using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaktionslogik für TextBoxMitValidierung.xaml
    /// </summary>
    public partial class TextBoxMitValidierung : UserControl
    {
        public event EventHandler EingabeTextChanged;

        public static readonly SolidColorBrush fehlerFarbe = new SolidColorBrush(Colors.Red);
        public static readonly SolidColorBrush korrekteFarbe = new SolidColorBrush(Colors.Green);

        private string fehlerKommentar = "falsche Eingabe";
        private string korrekterKommentar = "korrekte Eingabe";
        private string regex = "";
        public bool pflichtfeld { get; set; }

        public TextBoxMitValidierung()
        {
            InitializeComponent();
            this.pflichtfeld = false;
        }

        public void SetRegex(string regex)
        {
            this.regex = regex;
        }

        public void SetFehlerKommentar(string fehlerKommentar)
        {
            this.fehlerKommentar = fehlerKommentar;
        }

        public void SetKorrekterKommentar(string korrekterKommentar)
        {
            this.korrekterKommentar = korrekterKommentar;
        }

        public bool Ueberpruefung()
        {
            if (this.pflichtfeld && this.IsEmpty())
            {
                this.kommentarLabel.Foreground = fehlerFarbe;
                this.kommentarLabel.Content = this.fehlerKommentar;
                return false;
            }
            if (!IsEmpty())
            {
                if (Regex.IsMatch(this.validierteTextBox.Text, this.regex))
                {
                    // korrekte Eingabe
                    this.kommentarLabel.Foreground = korrekteFarbe;
                    this.kommentarLabel.Content = this.korrekterKommentar;
                    return true;
                }
                else
                {
                    // falsche Eingabe
                    this.kommentarLabel.Foreground = fehlerFarbe;
                    this.kommentarLabel.Content = this.fehlerKommentar;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /*private void Eingabe_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Ueberpruefung();
        }*/

        private void Eingabe_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EingabeTextChanged != null)
            {
                EingabeTextChanged(this, EventArgs.Empty);
            }
            this.Ueberpruefung();
        }

        public string GetEingabe()
        {
            return this.validierteTextBox.Text;
        }

        public void SetEingabe(String text)
        {
            this.validierteTextBox.Text = text;
        }

        private bool IsEmpty()
        {
            return this.validierteTextBox.Text == null || this.validierteTextBox.Text == "";
        }
    }
}
