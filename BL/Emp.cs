using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;
namespace BL
{
    [Serializable]
    public class Emp : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string _lastname;
        public string LastName
        {
            get
            { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged("LastName");
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _sname;
        public string SName
        {
            get { return _sname; }
            set
            {
                _sname = value;
                OnPropertyChanged("SName");
            }
        }

        public string FIO
        {
            get
            {
                string result = string.Empty;
                if (_lastname != null) result += _lastname;
                if (_name != null) result += " " + _name.Substring(0, 1) + ".";
                if (_sname != null) result += _sname.Substring(0, 1) + ".";
                return result;
            }
        }

        private Pos _pos;
        public virtual Pos Pos
        {
            get { return _pos; }
            set
            {
                _pos = value;
                OnPropertyChanged("Pos");
            }
        }

        public int PosId { get; set; }
        public string PosName
        {
            get
            { if (Pos != null) return Pos.Name; else return ""; }
        }

        private Dep _dep;
        public virtual Dep Dep
        {
            get { return _dep; }
            set
            {
                _dep = value;
                OnPropertyChanged("Dep");
            }
        }

        public int DepId { get; set; }
        public string DepName
        {
            get
            { if (Dep != null) return Dep.Name; else return ""; }
        }

        private string _internalTel;
        public string InternalTel
        {
            get { return _internalTel; }
            set
            {
                _internalTel = value;
                OnPropertyChanged("InternalTel");
            }
        }

        private string _mobileTel;
        public string MobileTel
        {
            get { return _mobileTel; }
            set
            {
                _mobileTel = value;
                OnPropertyChanged("MobileTel");
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _emailPass;
        public string EmailPass
        {
            get { return _emailPass; }
            set
            {
                _emailPass = value;
                OnPropertyChanged("EmailPass");
            }
        }

        private string _domainPass;
        public string DomainPass
        {
            get { return _domainPass; }
            set
            {
                _domainPass = value;
                OnPropertyChanged("DomainPass");
            }
        }

        private string _trueCryptPass;
        public string TrueCryptPass
        {
            get { return _trueCryptPass; }
            set
            {
                _trueCryptPass = value;
                OnPropertyChanged("TrueCryptPass");
            }
        }

        private string _eroomPass;
        public string ERoomPass
        {
            get { return _eroomPass; }
            set
            {
                _eroomPass = value;
                OnPropertyChanged("ERoomPass");
            }
        }

        private string _skypeName;
        public string SkypeName
        {
            get { return _skypeName; }
            set
            {
                _skypeName = value;
                OnPropertyChanged("SkypeName");
            }
        }

        private string _skypePass;
        public string SkypePass
        {
            get { return _skypePass; }
            set
            {
                _skypePass = value;
                OnPropertyChanged("SkypePass");
            }
        }

        private string _icqName;
        public string IcqName
        {
            get { return _icqName; }
            set
            {
                _icqName = value;
                OnPropertyChanged("IcqName");
            }
        }

        private string _icqPass;
        public string IcqPass
        {
            get { return _icqPass; }
            set
            {
                _icqPass = value;
                OnPropertyChanged("IcqPass");
            }
        }

        private string _gmail;
        public string Gmail
        {
            get { return _gmail; }
            set
            {
                _gmail = value;
                OnPropertyChanged("Gmail");
            }
        }

        private string _mango;
        public string Mango
        {
            get { return _mango; }
            set
            {
                _mango = value;
                OnPropertyChanged("Mango");
            }
        }

        private string _comments;
        public string Comments
        {
            get { return _comments; }
            set
            {
                _comments = value;
                OnPropertyChanged("Comments");
            }
        }

        private bool _hideInSpr;
        public bool HideInSpr
        {
            get { return _hideInSpr; }
            set
            {
                _hideInSpr = value;
                OnPropertyChanged("Comments");
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
