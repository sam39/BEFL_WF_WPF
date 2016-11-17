﻿using System;
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
using GalaSoft.MvvmLight.Messaging;
namespace WPF.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register(this, new Action<Uri>(Navigete));
            Messenger.Default.Register(this, new Action<string>(Back));
        }

        private void Navigete(Uri uri)
        {
            MainFrame.NavigationService.Navigate(uri);
        }

        private void Back(string cmd)
        {
            if (cmd == "GoBack") MainFrame.NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            Messenger.Default.Send<Uri>(new Uri("View\\emps.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri("View\\Page2.xaml", UriKind.Relative));
        }
         

        private void btnDeps_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send<Uri>(new Uri("View\\deps.xaml", UriKind.Relative));
        }

        private void btnPoss_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send<Uri>(new Uri("View\\poss.xaml", UriKind.Relative));
        }
    }
}
