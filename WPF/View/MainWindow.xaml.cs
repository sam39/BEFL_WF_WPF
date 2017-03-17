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
using System.Management;

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
            Messenger.Default.Register(this, new Action<BL.Dic>(SelectFromDic));
            Messenger.Default.Register(this, new Action<FlowDocument>(PrintDocument));
        }

        private void PrintDocument(FlowDocument doc)
        {
            Page v = new View.report();
            ViewModels.reportViewModel vm = new ViewModels.reportViewModel(doc);
            v.DataContext = vm;
            MainFrame.Navigate(v);
        }

        private void SelectFromDic(BL.Dic dic)
        {
            Page v = new View.dicdata();
            ViewModels.dicdataViewModel vm = new ViewModels.dicdataViewModel(dic);
            vm.SelectionMode = true;
            v.DataContext = vm;
            MainFrame.Navigate(v);
        }

        private void navigateToPage(Infrastrucrure.PageMessage mess)
        {
            Page v =  null;
            ViewModels.IViewModel vm = null;
            if (mess.PageType == typeof(View.emps))
            {
                v = new View.emps();
                vm = new ViewModels.empsViewModel();
            }

            if (mess.PageType == typeof(View.deps))
            {
                v = new View.deps();
                vm = new ViewModels.depsViewModel();
            }

            if (mess.PageType == typeof(View.comps))
            {
                v = new View.comps();
                vm = new ViewModels.compsViewModel();
            }

            if (mess.PageType == typeof(View.poss))
            {
                v = new View.poss();
                vm = new ViewModels.possViewModel();
            }

            if (mess.PageType == typeof(View.monitor))
            {
                v = new View.monitor();
                vm = new ViewModels.monitorViewModel();
            }

            if (mess.PageType == typeof(View.misc))
            {
                v = new View.misc();
                vm = new ViewModels.miscViewModel();
            }

            if (mess.PageType == typeof(ViewModels.printerViewModel))
            {
                v = new View.printer();
                vm = new ViewModels.printerViewModel();
            }

            v.DataContext = vm;

            if (mess.Action == Infrastrucrure.MessageAction.Select)
            {
                vm.SelectionMode = true;
            }

            MainFrame.Navigate(v);
        }

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
            Messenger.Default.Send<PageMessage>
               (new PageMessage { Action = MessageAction.Browse, PageType = typeof(View.emps) });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Messenger.Default.Send<PageMessage>
                (new PageMessage { Action = MessageAction.Browse, PageType = typeof(View.comps) });
       
        }
         

        private void btnDeps_Click(object sender, RoutedEventArgs e)
        {

            Messenger.Default.Send<PageMessage>
                (new PageMessage { Action = MessageAction.Browse, PageType = typeof(View.deps) });
        }

        private void btnPoss_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send<PageMessage>
                (new PageMessage { Action = MessageAction.Browse, PageType = typeof(View.poss) });
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            View.settings view = new settings();
            MainFrame.Navigate(view);           
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            View.dicdata view = new dicdata();
            view.DataContext = new ViewModels.dicdataViewModel(BL.Dic.ТипСистемы);
            MainFrame.Navigate(view);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {           
            Messenger.Default.Send<PageMessage>
                (new PageMessage { Action = MessageAction.Browse, PageType = typeof(View.monitor) });
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send<PageMessage>
                (new PageMessage { Action = MessageAction.Browse, PageType = typeof(View.misc)});
        }

        private void btnMc_Click(object sender, RoutedEventArgs e)
        {
            View.mc view = new View.mc();
            view.DataContext = new ViewModels.mcViewModel();
            MainFrame.Navigate(view);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send<PageMessage>
                (new PageMessage { Action = MessageAction.Browse, PageType = typeof(ViewModels.printerViewModel) });
        }
    }
}
