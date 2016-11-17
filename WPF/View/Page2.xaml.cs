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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;


namespace WPF.View
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        BL.UnitOfWork UoW = new BL.UnitOfWork();

        private void button_Click(object sender, RoutedEventArgs e)
        {
            BL.Dep dep  = UoW.DivisionRepository.GetByID(1);
            Messenger.Default.Send<BL.Dep>(dep);
        }
    }
}
