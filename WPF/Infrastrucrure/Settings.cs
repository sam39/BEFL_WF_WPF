using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace WPF.Infrastrucrure
{
    public class Settings : INotifyPropertyChanged
    {
        private string _loginAdminWS;
        public string LoginAdminWS
        {
            get { return _loginAdminWS; }
            set { _loginAdminWS = value; }
        }

        private string _passAdminWS;
        public string PassAdminWS
        {
            get { return _passAdminWS; }
            set { _passAdminWS = value; }
        }

        public void save()
        {
            XmlSerializer ser = new XmlSerializer(typeof(Settings));
            TextWriter writer = new StreamWriter("config.xml", false, Encoding.GetEncoding(1251));
            ser.Serialize(writer, this);
            writer.Close();
        }

        public static Settings read()
        {
            Settings s = new Settings();
            if (File.Exists("config.xml"))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(Settings));
                FileStream myFileStream = new FileStream("config.xml", FileMode.Open);
                s = (Settings)mySerializer.Deserialize(myFileStream);
                myFileStream.Close();
            }
            return s;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
