using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF.ViewModels
{
    class empsViewModel : DependencyObject
    {


        public string filteText
        {
            get { return (string)GetValue(filteTextProperty); }
            set { SetValue(filteTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for filteText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty filteTextProperty =
            DependencyProperty.Register("filteText", typeof(string), typeof(empsViewModel), new PropertyMetadata(""));

    }
}
