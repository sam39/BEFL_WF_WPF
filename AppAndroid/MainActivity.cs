using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
//using System.Xml.Serialization;
//using Android.Content.Res;
//using System.IO;
//using System.Collections.Generic;

namespace AppAndroid
{
    [Activity(Label = "AppAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            //string filepath = "emp.xml";
            //XmlSerializer serializer = new XmlSerializer(typeof(List<BL.Emp>));//initialises the serialiser

            //AssetManager assets = ApplicationContext.Assets;
            //StreamReader reader = new StreamReader(assets.Open(filepath)); //Initialises the reader
            ////Stream reader = new FileStream(filepath, FileMode.Open); //Initialises the reader
            //List<BL.Emp> deserializedList;

            //deserializedList = (List<BL.Emp>)serializer.Deserialize(reader); //reads from the xml file and inserts it in this variable
            //reader.Close(); //closes the reader

            //return deserializedList;

        }
    }
}

