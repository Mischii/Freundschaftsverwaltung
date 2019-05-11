﻿using System;
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
using M120Projekt.UserControls;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ContentControl cc = new ContentControl();
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

            Grid.SetRow(cc, 1);
            Hauptansicht.Children.Add(cc);
            cc.Content = new AlleFreunde(cc);
            Titel.Content = "Freundschaftsverwaltung";

        }
        
    }
}
