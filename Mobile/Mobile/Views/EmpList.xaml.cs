using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobile.ViewModels;
namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpList : ContentPage
    {
        EmpListViewModel viewModel;
        public EmpList()
        {
            InitializeComponent();
            BindingContext = viewModel = new EmpListViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var emp = args.SelectedItem as BL.Emp;
            if (emp == null)
                return;

            await Navigation.PushAsync(new EmpDetails(new EmpDetailsViewModel(emp)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }
    }
}