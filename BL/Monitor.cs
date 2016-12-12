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

        public override string Name
        {
            get
            {
                return _model + " " + _diazonal.Name;
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
            }
        }

        private DicData _diazonal;
        public DicData Diagonal
        {
            get { return _diazonal; }
            set
            {
                _diazonal = value;
                OnPropertyChanged("Diagonal");
            }

        }

        private Emp _emp;
        public virtual Emp Emp
        {
            get { return _emp; }
            set { _emp = value; }
        }

        public string EmpName
        {
            get
            {
                if (_emp != null) return _emp.Name;
                else return string.Empty;
            }
        }


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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
