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
    public partial class MainWindow : Page
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void empGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (empGrid.SelectedValue != null)
                empGrid.ScrollIntoView(empGrid.SelectedValue);
        }

        private void empGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (empGrid.SelectedValue != null)
            empGrid.ScrollIntoView(empGrid.SelectedValue);
        }

        private void Dep_Click(object sender, RoutedEventArgs e)
        {
            View.dep d = new View.dep();
            this.NavigationService.Navigate(new View.dep(new BL.Dep()));
            d.Return += new ReturnEventHandler<BL.Dep>(setdep);

        }

        private void setdep(object sender, ReturnEventArgs<BL.Dep> e)
        {
            //this.OnReturn(e);
        }
    }
}
