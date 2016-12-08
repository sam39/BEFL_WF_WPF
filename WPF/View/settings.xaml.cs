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
    /// Логика взаимодействия для settings.xaml
    /// </summary>
    public partial class settings : Page
    {
        public settings()
        {
            InitializeComponent();
            DataContext = Settings;
        }

        private Infrastrucrure.Settings _settings;
        public Infrastrucrure.Settings Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = Infrastrucrure.Settings.read();
                    PasswordBox1.Password = _settings.PassAdminWS;
                }

                return _settings;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Settings != null)
            {
                Settings.PassAdminWS = PasswordBox1.Password;
                Settings.save();
            }

        }
    }
}
