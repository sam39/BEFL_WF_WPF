using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Mobile
{
    public partial class App : Application
    {
        //public const string DATABASE_NAME = "emp.xml";
        //public static BeflRepository database;
        //public static BeflRepository Database
        //{
        //    get
        //    {
        //        if (database == null)
        //        {
        //            database = new BeflRepository(DATABASE_NAME);
        //        }
        //        return database;
        //    }
        //}

        public App()
        {
            InitializeComponent();

            //MainPage = new Mobile.MainPage();
            MainPage = new Views.EmpList();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
