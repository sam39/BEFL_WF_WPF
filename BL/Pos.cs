using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BL
{
    [Serializable]
    public class Pos : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        //private ICollection<Emp> _emps;

        //public ICollection<Emp> Emps
        //{
        //    get { return _emps; }
        //    set {
        //        _emps = value;
        //        OnPropertyChanged("Emps");
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
