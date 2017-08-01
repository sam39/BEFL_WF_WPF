using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Content.Res;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace Mobile.Droid
{

    [Activity(Label = "Mobile", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);                     

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        private IEnumerable<BL.Emp> emplist;
        public IEnumerable<BL.Emp> EmpList
        {
            get
            {
                return emplist;
            }
        }
    }
}

