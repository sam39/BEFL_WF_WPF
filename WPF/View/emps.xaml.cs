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

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //BL.UnitOfWork uw = new BL.UnitOfWork();
            //IEnumerable<BL.Emp> emps =  uw.EmpRepository.GetAll();
            //empGrid.ItemsSource = emps;

            //IEnumerable<BL.Pos> posList = uw.PosRepository.GetAll();
            //PosColumn.ItemsSource = posList;

            //IEnumerable<BL.Dep> depList = uw.DivisionRepository.GetAll();
            //DepColumn.ItemsSource = depList;
        }
    }
}
