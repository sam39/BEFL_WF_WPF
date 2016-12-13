using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BL
{
    public abstract class Mc: INotifyPropertyChanged
    {
        private string _invNum;
        public string InvNum
        {
            get { return _invNum; }
            set
            {
                _invNum = value;
                OnPropertyChanged("InvNum");
            }

        }

        public string EmpFIO
        {
            get
            {
                if (_emp != null) return _emp.FIO;
                else return string.Empty;
            }
        }

        private Emp _emp;
        public virtual Emp Emp
        {
            get { return _emp; }
            set
            {
                _emp = value;
                OnPropertyChanged("Emp");
                OnPropertyChanged("EmpFIO");
            }
        }

        public abstract string Name { get;}
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
