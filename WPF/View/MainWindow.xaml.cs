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
using GalaSoft.MvvmLight.Messaging;
using WPF.Infrastrucrure;

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
            Messenger.Default.Register(this, new Action<Uri>(Navigate));
            Messenger.Default.Register(this, new Action<Page>(Navigate));
            Messenger.Default.Register(this, new Action<string>(Back));
            Messenger.Default.Register(this, new Action<Infrastrucrure.PageMessage>(navigateToPage));
        }


        private void navigateToPage(Infrastrucrure.PageMessage mess)
        {
            Page v =  null;
            ViewModels.IViewModel vm = null;
            if (mess.PageType == typeof(View.deps))
            {
                v = DepsView;
                vm = _depsViewModel;
            }

            if (mess.Action == Infrastrucrure.MessageAction.Select)
            {
                vm.SelectionMode = true;
            }
         
            MainFrame.Navigate(v);
        }


        private View.emps _empsView;
        public View.emps EmpsView
        {
            get
            {
                if (_empsView == null) _empsView = new View.emps();
                if (_empsViewModel == null) _empsViewModel = new ViewModels.empsViewModel();
                _empsView.DataContext = _empsViewModel;
                return _empsView;
            }
        }

        //Времменно оставляем
        private ViewModels.empsViewModel _empsViewModel;
        public ViewModels.empsViewModel EmpsViewModel
        {
            get
            {
                //if (_empsViewModel == null) _empsViewModel = new ViewModels.empsViewModel();
                return _empsViewModel;
            }
        }

        private View.deps _depsView;
        public View.deps DepsView
        {
            get
            {
                if (_depsView == null) _depsView = new View.deps();
                if (_depsViewModel == null) _depsViewModel = new ViewModels.depsViewModel();
                _depsView.DataContext = _depsViewModel;
                return _depsView;
            }
            //set
            //{
            //    _depsView = value;
            //}
        }

        private ViewModels.depsViewModel _depsViewModel;
        //public ViewModels.depsViewModel DepsViewModel
        //{
        //    get
        //    {
        //        if (_depsViewModel == null) _depsViewModel = new ViewModels.depsViewModel();
        //        return _depsViewModel;
        //    }
        //    set
        //    {
        //        _depsViewModel = value;
        //    }

        //}


        private void Navigate(Uri uri)
        {
            MainFrame.NavigationService.Navigate(uri);
        }

        private void Navigate(Page page)
        {
            MainFrame.NavigationService.Navigate(page);
        }

        private void Back(string cmd)
        {
            if (cmd == "GoBack" && MainFrame.NavigationService.CanGoBack) MainFrame.NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmpsView.DataContext = EmpsViewModel;
            MainFrame.NavigationService.Navigate(EmpsView);
            //Messenger.Default.Send<Uri>(new Uri("View\\emps.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Uri("View\\Page2.xaml", UriKind.Relative));
        }
         

        private void btnDeps_Click(object sender, RoutedEventArgs e)
        {

            Messenger.Default.Send<PageMessage>
                (new PageMessage { Action = MessageAction.Browse, PageType = typeof(View.deps) });
        }

        private void btnPoss_Click(object sender, RoutedEventArgs e)
        {
            //Messenger.Default.Send<Uri>(new Uri("View\\poss.xaml", UriKind.Relative));
            //MainFrame.NavigationService.Navigate(new poss(true);
        }
    }
}
