using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Android.Content.Res;

[assembly: Dependency(typeof(Mobile.Droid.BeflRepository))]
namespace Mobile.Droid
{


    public class BeflRepository :  IBeflRepository  
    {
        private List<BL.Emp> deserializedList;
        public IEnumerable<BL.Emp> GetEmps()
        {
            string filepath = "emp.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<BL.Emp>));//initialises the serialiser

            AssetManager assets = Android.App.Application.Context.Assets;

            StreamReader reader = new StreamReader(assets.Open(filepath)); //Initialises the reader
            deserializedList = (List<BL.Emp>)serializer.Deserialize(reader); //reads from the xml file and inserts it in this variable
            return deserializedList;
        }

    }

}