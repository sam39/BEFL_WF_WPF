using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace BL
{
    public class Misc : Mc
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _dsc;
        public string Dsc
        {
            get { return _dsc; }
            set
            {
                _dsc = value;
                OnPropertyChanged("Dsc");
            }
        }

        public override string Name
        {
            get { return _dsc;}
        }

        //private BL.Emp _emp;
        //public virtual BL.Emp Emp
        //{
        //    get { return _emp; }
        //    set
        //    {
        //        _emp = value;
        //        OnPropertyChanged("Emp");
        //    }
        //}


        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
