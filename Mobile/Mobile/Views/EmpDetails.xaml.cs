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
    public partial class EmpDetails : ContentPage
    {
        EmpDetailsViewModel viewModel;
        public EmpDetails()
        {
            InitializeComponent();
        }

        public EmpDetails(EmpDetailsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}