using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            friendsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            BL.Emp selectedEmp = (BL.Emp)e.SelectedItem;
            EmpPage friendPage = new EmpPage();
            friendPage.BindingContext = selectedEmp;
            await Navigation.PushAsync(friendPage);
        }
        // обработка нажатия кнопки добавления
        private async void CreateFriend(object sender, EventArgs e)
        {
            BL.Emp emp = new BL.Emp();
            EmpPage empPage = new EmpPage();
            empPage.BindingContext = emp;
            await Navigation.PushAsync(empPage);
        }

    }
}
