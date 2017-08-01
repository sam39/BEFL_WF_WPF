using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BL
{
    public class Monitor: Mc, INotifyPropertyChanged
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

        private string _model;
        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged("Model");
                OnPropertyChanged("Name");
            }
        }

        private DicData _diagonal;
        public virtual DicData Diagonal
        {
            get { return _diagonal; }
            set
            {
                _diagonal = value;
                OnPropertyChanged("Diagonal");
                OnPropertyChanged("Name");
            }
        }

        public virtual string DiagName
        {
            get
            {
                if (_diagonal != null)
                    return _diagonal.Name;
                else return "";
            }
        }

        public override string Name
        {
            get
            {
                string result = "Монитор: ";
                if (_model != null) result += _model;
                if (Diagonal != null) result += " " + Diagonal.Name;
                return result;
            }
        }


        //private Emp _emp;
        //public virtual Emp Emp
        //{
        //    get { return _emp; }
        //    set
        //    {
        //        _emp = value;
        //        OnPropertyChanged("Emp");
        //        OnPropertyChanged("EmpFIO");
        //    }
        //}

        //public string EmpFIO
        //{
        //    get
        //    {
        //        if (_emp != null) return _emp.FIO;
        //        else return string.Empty;
        //    }
        //}

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                OnPropertyChanged("Comment");
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
