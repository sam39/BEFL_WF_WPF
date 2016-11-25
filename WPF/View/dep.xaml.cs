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

namespace WPF.View
{
    /// <summary>
    /// Логика взаимодействия для dep.xaml
    /// </summary>
    public partial class dep : PageFunction<BL.Dep>
    {
        public dep()
        {
            InitializeComponent();
        }
        public dep(BL.Dep dep)
        {
            InitializeComponent();
        }

        private void Testbutton_Click(object sender, RoutedEventArgs e)
        {
            ViewModels.depsViewModel dc = DataContext as ViewModels.depsViewModel;
            this.OnReturn(new ReturnEventArgs<BL.Dep>(dc.Selected as BL.Dep));
        }
    }
}
