using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpPage : ContentPage
    {
        public EmpPage()
        {
            InitializeComponent();
        }

        //private void SaveFriend(object sender, EventArgs e)
        //{
        //    var emp = (BL.Emp)BindingContext;
        //    if (!String.IsNullOrEmpty(emp.Name))
        //    {
        //        App.Database.SaveItem(emp);
        //    }
        //    this.Navigation.PopAsync();
        //}

        //private void DeleteFriend(object sender, EventArgs e)
        //{
        //    var emp = (BL.Emp)BindingContext;
        //    App.Database.DeleteItem(emp.Id);
        //    this.Navigation.PopAsync();
        //}

        //private void Cancel(object sender, EventArgs e)
        //{
        //    this.Navigation.PopAsync();
        //}
    }
}
