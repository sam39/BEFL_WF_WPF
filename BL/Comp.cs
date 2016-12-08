using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BL
{
    public enum CompType { Desktop, Notebook};
    public class Comp: INotifyPropertyChanged
    {
        public int Id { get; set; }

        private CompType _compType;
        public CompType CompType
        {
            get { return _compType; }
            set
            {
                _compType = value;
                OnPropertyChanged("CompType");
            }
        }


        string _netName;
        public string NetName
        {
            get
            {
                return _netName;
            }
            set
            {
                _netName = value;
                OnPropertyChanged("NetName");
            }
         
        }

        string _cpuName;
        public string CpuName
        {
            get
            {
                return _cpuName;
            }
            set
            {
                _cpuName = value;
                OnPropertyChanged("CpuName");

            }
        }

        string _cpuCoreNum;
        public string CpuCoreNum
        {
            get
            {
                return _cpuCoreNum;
            }
            set
            {
                _cpuCoreNum = value;
                OnPropertyChanged("CpuCoreNum");
            }
        }

        string _memory;
        public string Memory
        {
            get
            {
                return _memory;
            }
            set
            {
                _memory = value;
                OnPropertyChanged("Memory");
            }
        }

        private string _hdd;
        public string Hdd
        {
            get { return _hdd; }
            set
            {
                _hdd = value;
                OnPropertyChanged("Hdd");
            }
        }

        private string _cdcom;
        public string CdRom
        {
            get { return _cdcom; }
            set
            {
                _cdcom = value;
                OnPropertyChanged("CdRom");
            }
        }

        private string _os;
        public string OS
        {
            get { return _os; }
            set
            {
                _os = value;
                OnPropertyChanged("OS");
            }
        }

        private string _mainBoadr;
        public string MainBoard
        {
            get { return _mainBoadr; }
            set
            {
                _mainBoadr = value;
                OnPropertyChanged("MainBoard");
            }
        }

        private string _video;
        public string Video
        {
            get { return _video; }
            set
            {
                _video = value;
                OnPropertyChanged("Video");
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
