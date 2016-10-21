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
        }


        private void Newbutton_Click(object sender, RoutedEventArgs e)
        {
            empGrid.SelectedIndex =  empGrid.Items.Count - 1;
        }


        private void Editbutton_Click(object sender, RoutedEventArgs e)
        {
            //EditForm.Visibility = Visibility.Visible;
        }

        private void Savebutton_Click(object sender, RoutedEventArgs e)
        {
            //EditForm.Visibility = Visibility.Collapsed;
        }
    }
}
