using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BL
{
    public class Comp: INotifyPropertyChanged
    {
        public int Id { get; set; }

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



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
